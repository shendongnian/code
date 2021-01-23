    public class Blah
    {
        public int id { get; set; }
        public string blahh { get; set; }
    }
    public class Doh
    {
        public int id { get; set; }
        public string dohh { get; set; }
        public string mahh { get; set; }
    }
    class Program
    {
        public static List<T> Whatever<T>(int count) where T: new()
        {
            return Enumerable.Range(0, count).Select((i) => new T()).ToList();
        }
        static void Main(string[] args)
        {
            var list=Whatever<Doh>(100);
            // list containts 100 of "Doh"
        }
    }
