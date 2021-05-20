using IndianStateCensusAnalyzer;
using IndianStateCensusAnalyzer.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyzer.CensusAnalyser;

namespace CensusAnalyzerTest
{
    [TestClass]
    public class Tests
    {

        //CensusAnalyser.CensusAnalyser censusAnalyser;

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string wrongIndianStateCodeHeaders = "SrNo,State Name,TINAAA,StateCode";
        static string delimiterIndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string delimiterIndianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\SANTANU\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CsvFiles\IndiaStateCensusData.csv";
        static string delimiterIndianStateCensusFilePath = @"C:\Users\SANTANU\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CsvFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\SANTANU\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\SANTANU\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CsvFiles\IndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\SANTANU\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CsvFiles\WrongIndiaStateCode.csv";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\SANTANU\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CsvFiles\DelimiterIndiaStateCode.csv";



        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            NUnit.Framework.Assert.Pass();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            NUnit.Framework.Assert.AreEqual(29, totalRecord.Count);
            NUnit.Framework.Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_Should_INCORRECT_HEADER_Exception()
        {
            var censusException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturn_FILE_NOT_FOUND_Exception()
        {
            var stateException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        //UC 2 [Start]
        [Test]
        public void GivenWrongIndianCensusCountryName_WhenReaded_ShouldReturn_NO_SUCH_COUNTRY_Exception()
        {
            var stateException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.BRAZIL, indianStateCensusHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY, stateException.eType);
        }
        [Test]
        public void GivenIndianStateCodeDataFile_WhenReaded_ShouldReturnStateCodeDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            NUnit.Framework.Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianStateCodeDataFile_WhenReaded_ShouldReturn_FILE_NOT_FOUND_Exception()
        {
            var stateException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        [Test]
        public void GivenWrongIndianStateCodeDataHeader_WhenReaded_ShouldReturn_INCORRECT_HEADER_Exception()
        {
            var stateException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, wrongIndianStateCodeHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
        [Test]
        public void GivenWrongIndianStateCodeCountryName_WhenReaded_ShouldReturn_NO_SUCH_COUNTRY_Exception()
        {
            var stateException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.BRAZIL, wrongIndianStateCodeHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY, stateException.eType);
        }
        //UC 3 [End]

        //Additional Use Cases for Practice
        [Test]
        public void GivenDelimiterIndianStateCensusDataFile_WhenReaded_Should_INCORRECT_HEADER_Exception()
        {
            var censusException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCensusFilePath, Country.INDIA, delimiterIndianStateCensusHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        [Test]
        public void GivenDelimiterIndianStateCensusDataFile_WhenReaded_ShouldReturn_FILE_NOT_FOUND_Exception()
        {
            var stateException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCensusFilePath, Country.INDIA, delimiterIndianStateCensusHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        [Test]
        public void GivenDelimiterIndianStateCensusDataFile_WhenReaded_ShouldReturn_NO_SUCH_COUNTRY_Exception()
        {
            var stateException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCensusFilePath, Country.BRAZIL, delimiterIndianStateCensusHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY, stateException.eType);
        }
        [Test]
        public void GivenDelimiterIndianStateCodeDataFile_WhenReaded_Should_INCORRECT_HEADER_Exception()
        {
            var censusException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCodeFilePath, Country.INDIA, delimiterIndianStateCodeHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        [Test]
        public void GivenDelimiterIndianStateCodeDataFile_WhenReaded_ShouldReturn_FILE_NOT_FOUND_Exception()
        {
            var stateException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCodeFilePath, Country.INDIA, delimiterIndianStateCodeHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        [Test]
        public void GivenDelimiterIndianStateCodeDataFile_WhenReaded_ShouldReturn_NO_SUCH_COUNTRY_Exception()
        {
            var stateException = NUnit.Framework.Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCodeFilePath, Country.BRAZIL, delimiterIndianStateCodeHeaders));
            NUnit.Framework.Assert.AreEqual(CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY, stateException.eType);

        }

    }

}
