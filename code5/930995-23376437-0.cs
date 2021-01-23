    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{""d"": ""{\""TickTime\"":\""29/04/2014 19:13:41\"",\""Symbols\"":[{\""I\"":61,\""H\"":0.8551,\""L\"":0.8516,\""A\"":0.855,\""B\"":0.8545},{\""I\"":62,\""H\"":1301.4,\""L\"":1286.3,\""A\"":1296.6,\""B\"":1296.4}]}""}";
            IsoDateTimeConverter dateConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "dd/MM/yyyy HH:mm:ss"
            };
            var outerRoot = JsonConvert.DeserializeObject<OuterRootObject>(json);
            var root = JsonConvert.DeserializeObject<RootObject>(outerRoot.d, dateConverter);
            Console.WriteLine("TickTime: " + root.TickTime.ToString("dd-MMM-yyyy hh:mm:ss tt"));
            foreach (Result r in root.Symbols)
            {
                Console.WriteLine("I: " + r.I);
                Console.WriteLine("A: " + r.A);
                Console.WriteLine("B: " + r.B);
                Console.WriteLine("H: " + r.H);
                Console.WriteLine("L: " + r.L);
                Console.WriteLine();
            }
        }
    }
    public class OuterRootObject
    {
        public string d { get; set; }
    }
    public class RootObject
    {
        public DateTime TickTime { get; set; }
        public List<Result> Symbols { get; set; }
    }
    public class Result
    {
        public int I { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double H { get; set; }
        public double L { get; set; }
    }
