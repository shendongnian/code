    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace ConsoleApplication2
    {
    class Program
    {
        private static void Main(string[] args)
        {
          //  const string folder = @"C:\Users\computing\Desktop\algorithms\CMP1124M_Assigment_Files";
            const string folder = @"C:\Temp\SO";
            var filenames = new[] { @"Date.txt", @"Day.txt", @"SH1_Close.txt", @"SH1_Diff.txt", @"SH1_Open.txt", @"SH1_Volume.txt" };
            var dataCombiner = new DataCombiner(folder, filenames);
            var stockParser = new StockParser();
            foreach (var stock in dataCombiner.GetCombinedData(stockParser.Parse)) //can also use where clause here
            { 
                if (ShowRow(stock))
                {
                    var outputText = stock.ToString();
                    Console.WriteLine(outputText);
                }
            }
            Console.ReadLine();
        }
        private static bool ShowRow(Stock stock)
        {
            //use input from user etc...
            return     (stock.DayOfWeek == "Tuesday" || stock.DayOfWeek == "Monday")
                    && stock.Volume > 1000 
                    && stock.Diff < 10; // etc
        }
    }
    internal class DataCombiner
    {
        private readonly string _folder;
        private readonly string[] _filenames;
        public DataCombiner(string folder, string[] filenames)
        {
            _folder = folder;
            _filenames = filenames;
        }
        private static IEnumerable<string> GetFilePaths(string folder, params string[] filenames)
        {
            return filenames.Select(filename => Path.Combine(folder, filename));
        }
         
        public IEnumerable<T> GetCombinedData<T>(Func<string[], T> parserMethod) where T : class
        {
            var filePaths = GetFilePaths(_folder, _filenames).ToArray();
            var files = filePaths.Select(filePath => new StreamReader(filePath)).ToList();
            var lineCounterFile = new StreamReader(filePaths.First());
            while (lineCounterFile.ReadLine() != null)// This can be replaced with a simple for loop if the files will always have a fixed number of rows
            {
                var rawData = files.Select(file => file.ReadLine()).ToArray();
                yield return parserMethod(rawData);
            }
        }
    }
    internal class Stock
    {
        public DateTime Date { get; set; }
        public string DayOfWeek { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Diff { get; set; }
        public int Volume { get; set; }
        public override string ToString()
        {
            //Whatever format you want
            return string.Format("{0:d} {1} {2} {3} {4} {5}", Date, DayOfWeek, Close, Diff, Open, Volume);
        }
    }
    internal class StockParser
    {
        public Stock Parse(string[] rawData)
        {
            //TODO: Error handling required here
            var stock = new Stock();
            stock.Date = DateTime.Parse(rawData[0]);
            stock.DayOfWeek = rawData[1];
            stock.Close = double.Parse(rawData[2]);
            stock.Diff = double.Parse(rawData[3]);
            stock.Open = double.Parse(rawData[4]);
            stock.Volume = int.Parse(rawData[5]); 
            return stock;
        }
        public string ParseToRawText(string[] rawData)
        {
            return string.Join(" ", rawData);
        }
    }
    }
