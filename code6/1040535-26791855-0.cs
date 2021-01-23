    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace CsvDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                string csvFile =
                    "Date,Open,High,Low,Close,Volume,Adj Close\r\n" +
                    "2012-11-01,77.60,78.12,77.37,78.05,186200,78.05";
                List<DailyValues> values = new List<DailyValues>();
                foreach(string line in Regex.Split(csvFile, "\r\n").Skip(1))
                {
                    values.Add(DailyValues.FromCsv(line));
                }
            }
        }
        class DailyValues
        {
            DateTime Date;
            decimal Open;
            decimal High;
            decimal Low;
            decimal Close;
            decimal Volume;
            decimal AdjClose;
            public static DailyValues FromCsv(string csvLine)
            {
                string[] values = csvLine.Split(',');
                DailyValues dailyValues = new DailyValues();
                dailyValues.Date = Convert.ToDateTime(values[0]);
                dailyValues.Open = Convert.ToDecimal(values[1]);
                dailyValues.High = Convert.ToDecimal(values[2]);
                dailyValues.Low = Convert.ToDecimal(values[3]);
                dailyValues.Close = Convert.ToDecimal(values[4]);
                dailyValues.Volume = Convert.ToDecimal(values[5]);
                dailyValues.AdjClose = Convert.ToDecimal(values[6]);
                return dailyValues;
            }
        }
    }
