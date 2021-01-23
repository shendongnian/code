    using Newtonsoft.Json;
    class Program
    {
        static void Main(string[] args)
        {
            var temp = JsonConvert.DeserializeObject<A>("{\"aprop\":\"2012-12-02T23:03:31Z\"}");
            Console.ReadKey();
        }
    }
