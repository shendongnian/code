    using System;
    using System.IO;
    using System.Web.Script.Serialization;
    
    public class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            var serializer = new JavaScriptSerializer();
            var json = File.ReadAllText("test.json");
            var people = serializer.Deserialize<Person[]>(json);
            Console.WriteLine(people[0].Name); // ABC
        }
    }
