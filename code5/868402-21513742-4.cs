    class Program
    {
        static void Main(string[] args)
        {
            Example example = new Example
            {
                Date1 = new DateTime(2014, 2, 2),
                Date2 = DateTime.MinValue,
                Inner = new Inner
                {
                    DateA = DateTime.MinValue,
                    DateB = new DateTime(1954, 1, 26)
                },
                MoreDates = new List<DateTime>
                {
                    new DateTime(1971, 11, 15),
                    DateTime.MinValue
                }
            };
            // Set up the serializer to use our date converter
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new MinDateToNullConverter());
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(example, settings);
            Console.WriteLine(json);
        }
    }
    class Example
    {
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public Inner Inner { get; set; }
        public List<DateTime> MoreDates { get; set; }
    }
    class Inner
    {
        public DateTime DateA { get; set; }
        public DateTime DateB { get; set; }
    }
