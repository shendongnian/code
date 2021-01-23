    public class OData<T> where T : IEnumerable
    {
        public T results { get; set; }
    }
    public class X
    {
        public string Prop { get; set; }
        public OData<List<int>> List { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var x = new X()
            {
                Prop = "test",
                List = new OData<List<int>> {results = new List<int>() {1, 2, 3}}
            };
            Console.WriteLine(JsonConvert.SerializeObject(x));
        }
    }
