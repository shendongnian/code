    using System;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    namespace Sandbox
    {
        class Program
        {
            private static void Main(string[] args)
            {
                //Added "person" to the JSON so it would deserialize
                var testData = "{\"result_code\":200, \"person\":{\"name\":\"John\", \"lastName\": \"Doe\"}}";
                var result = new JsonResult
                {
                    Data = JsonConvert.DeserializeObject(testData)
                };
                Console.WriteLine(result.Data);
                Console.ReadKey();
            }
        }
    }
