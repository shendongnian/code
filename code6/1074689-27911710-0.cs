    using System;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;    
    
    public class Foo
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public JObject Configuration { get; set; }
    }
    
    public class Test
    {
       public static void Main()
       {
           var json = File.ReadAllText("test.json");
           var foo = JsonConvert.DeserializeObject<Foo>(json);
           Console.WriteLine(foo.Configuration);
       }
        
    }
