    class Program
    {
        static void Main(string[] args)
        {
            IsoDateTimeConverter dateConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "dd.MM.yyyy"
            };
            Foo foo = new Foo { Date = new DateTime(2014, 3, 12) };
            // serialize an object containing a date using the custom date format
            string json = JsonConvert.SerializeObject(foo, dateConverter);
            Console.WriteLine(json);
            // deserialize the JSON with the custom date format back into an object
            Foo foo2 = JsonConvert.DeserializeObject<Foo>(json, dateConverter);
            Console.WriteLine("Day = " + foo2.Date.Day);
            Console.WriteLine("Month = " + foo2.Date.Month);
            Console.WriteLine("Year = " + foo2.Date.Year);
        }
    }
    class Foo
    {
        public DateTime Date { get; set; }
    }
