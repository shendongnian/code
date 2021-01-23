    class Program
    {
        static void Main(string[] args)
        {
            SomeThing st = new SomeThing
            {
                Alpha = "x.a",
                Beta = "x.b",
                ThisThing = new Thing { Alpha = "y.a", Beta = "y.b" },
                ThatThing = new Thing { Alpha = "z.a", Beta = "z.b" }
            };
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new SomeThingConverter());
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(st, settings);
            Console.WriteLine(json);
        }
        public class Thing
        {
            public string Alpha { get; set; }
            public string Beta { get; set; }
        }
        public class SomeThing : Thing
        {
            public Thing ThisThing { get; set; }
            public Thing ThatThing { get; set; }
        }
    }
