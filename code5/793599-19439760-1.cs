    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            { 
                ""Bool1"": true, 
                ""Bool2"": ""TRUE"", 
                ""Bool3"": false, 
                ""Bool4"": ""FALSE"",
                ""Other"": ""Say It Isn't True!"" 
            }";
            Foo foo = JsonConvert.DeserializeObject<Foo>(json, new BoolStringConverter());
            Console.WriteLine("Bool1: " + foo.Bool1);
            Console.WriteLine("Bool2: " + foo.Bool2);
            Console.WriteLine("Bool3: " + foo.Bool3);
            Console.WriteLine("Bool4: " + foo.Bool4);
            Console.WriteLine("Other: " + foo.Other);
        }
    }
    class Foo
    {
        public string Bool1 { get; set; }
        public string Bool2 { get; set; }
        public string Bool3 { get; set; }
        public string Bool4 { get; set; }
        public string Other { get; set; }
    }
