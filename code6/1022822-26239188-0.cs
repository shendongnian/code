    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{ ""date"" : ""2014/10/07"" }";
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            using (StreamReader sr = new StreamReader(ms))
            using (JsonTextReader jtr = new JsonTextReader(sr))
            {
                JsonSerializer ser = new JsonSerializer();
                ser.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "yyyy/MM/dd" });
                Foo foo = ser.Deserialize<Foo>(jtr);
                Console.WriteLine(foo.Date.ToLongDateString());
            }
        }
    }
    class Foo
    {
        public DateTime Date { get; set; }
    }
