    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            { 
                ""a"": 10,
                ""b"": ""foo"",
                ""c"": 30,
                ""d"": ""bar"",
            }";
            var stuff = JsonConvert.DeserializeObject<Stuff>(json);
            Console.WriteLine(stuff.A);
            Console.WriteLine(stuff.B);
            Console.WriteLine(stuff.Others["c"]);
            Console.WriteLine(stuff.Others["d"]);
        }
    }
