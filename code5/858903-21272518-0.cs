    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{ ""Date"" : ""09/12/2013"" }";
            MyObject obj = JsonConvert.DeserializeObject<MyObject>(json, 
                new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            DateTime date = obj.Date;
            Console.WriteLine("day = " + date.Day);
            Console.WriteLine("month = " + date.Month);
            Console.WriteLine("year = " + date.Year);
        }
    }
    class MyObject
    {
        public DateTime Date { get; set; }
    }
