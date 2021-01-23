    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    namespace CsvDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<DailyValues> values = File.ReadAllLines("C:\\Users\\Josh\\Sample.csv")
                                               .Skip(1)
                                               .Select(v => DailyValues.FromCsv(v))
                                               .ToList();
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
