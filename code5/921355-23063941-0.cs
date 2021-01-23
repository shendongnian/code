    using System;
    using Newtonsoft.Json;
    namespace Sandbox
    {
    class Program
    {
        private static void Main(string[] args)
        {
           var nestDto = new Dto
            {
                customfield_1 = 20,
                customfield_2 = "Test2"
            };
            var dto = new Dto
            {
                customfield_1 = 10,
                customfield_3 = new[] { nestDto },
                customfield_2 = "Test"
            };
            var jsonString = JsonConvert.SerializeObject(dto);
            Console.WriteLine(jsonString);
            var fromJsonString = JsonConvert.DeserializeObject<Dto>(jsonString);
            Console.WriteLine(fromJsonString.customfield_3[0].customfield_2); //Outputs Test2
            Console.ReadKey();
        }
    }
    class Dto
    {
        public int customfield_1 { get; set; }
        public string customfield_2 { get; set; }
        public Dto[] customfield_3 { get; set; }
    }
    }
