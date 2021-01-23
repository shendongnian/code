    class Program
    {
        static void Main(string[] args)
        {
            SomeThing st = new SomeThing
            {
                Alpha = "x.a",
                Beta = "x.b",
                ThisThing = new Thing { Alpha = "y.a", Beta = "y.b" },
                ThatThing = new SomeThingElse 
                { 
                    Alpha = "z.a", 
                    Beta = "z.b",
                    Delta = 42,
                    Epsilon = new Thing { Alpha = "e.a", Beta = "e.b" }
                }
            };
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new MyContractResolver();
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(st, settings);
            Console.WriteLine(json);
        }
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
    public class SomeThingElse : Thing
    {
        public int Delta { get; set; }
        public Thing Epsilon { get; set; }
    }
