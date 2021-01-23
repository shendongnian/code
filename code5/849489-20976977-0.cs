    class CaseInsensitiveDictionary<V> : Dictionary<string, V>
    {
        public CaseInsensitiveDictionary() : base(StringComparer.OrdinalIgnoreCase)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""Foo"" : 
                {
                    ""fiZZ"" : 1,
                    ""BUzz"" : ""yo""
                },
                ""BAR"" :
                {
                    ""dIt"" : 3.14,
                    ""DaH"" : true
                }
            }";
            var dict = JsonConvert.DeserializeObject<CaseInsensitiveDictionary<CaseInsensitiveDictionary<object>>>(json);
            Console.WriteLine(dict["foo"]["fizz"]);
            Console.WriteLine(dict["foo"]["buzz"]);
            Console.WriteLine(dict["bar"]["dit"]);
            Console.WriteLine(dict["bar"]["dah"]);
        }
    }
