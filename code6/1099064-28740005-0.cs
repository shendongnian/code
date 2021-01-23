    using System;
    using System.IO;
    
    using Newtonsoft.Json;
    
    public class Person
    {
        public string Id { get; set; }
        public string Name {get;set;}
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string text = "[{\"id\":\"42\",\"Name\":\"Bas Jansen\"},{\"id\":\"41\",\"Name\":\"Bas Jansen\"}]";
            var array = JsonConvert.DeserializeObject<Person[]>(text);
            Console.WriteLine(array.Length);
            Console.WriteLine(array[0].Id);
        }
    }
