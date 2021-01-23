    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""errors"": {},
                ""stuffToIgnore"" : ""foo bar"",
                ""data"": [
                        [""2014-06-13"", 2.9959, 3.0302, 2.9853, 0.0838, null, 2.9943, 27331.0, 51662.0],
                        [""2014-06-12"", 2.9092, 3.0017, 2.908, null, 0.0838, 2.9948, 35321.0, 47057.0]
                ]
            }";
            DataFormat df = JsonConvert.DeserializeObject<DataFormat>(json);
            foreach (Data item in df.Data)
            {
                Console.WriteLine("Date: " + item.Date.ToShortDateString());
                Console.WriteLine("Open: " + item.Open);
                Console.WriteLine("High: " + item.High);
                Console.WriteLine("Low: " + item.Low);
                Console.WriteLine("Last: " + item.Last);
                Console.WriteLine("Change: " + item.Change);
                Console.WriteLine("Settle: " + item.Settle);
                Console.WriteLine("Volume: " + item.Volume);
                Console.WriteLine("OpenInterest: " + item.OpenInterest);
                Console.WriteLine();
            }
        }
    }
