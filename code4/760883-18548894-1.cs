    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    class Program
    {
        static void Main(string[] args)
        {
            Widget w = new Widget { Id = 2, Name = "Joe Schmoe" };
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new WritablePropertiesOnlyResolver()
            };
            string json = JsonConvert.SerializeObject(w, settings);
            Console.WriteLine(json);
        }
    }
    class Widget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LowerCaseName
        {
            get { return (Name != null ? Name.ToLower() : null); }
        }
    }
