    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public class MyClass
    {
        public string A { get; set; }
        public int B { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            var json = @"
            {
                1: { ""a"": ""anything"", ""b"": 987 },
                2: { ""a"": ""something"", ""b"": 123 }
            }";
    
            var result = JsonConvert.DeserializeObject<IDictionary<int, MyClass>>(json);
            Console.WriteLine(result[2].A);
        }
    }
