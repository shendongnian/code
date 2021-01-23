    using System.Collections.Generic;
    using RestSharp;
    using RestSharp.Deserializers;
    using Newtonsoft.Json;
    
    namespace Freebase
    {
        public class ValueSet
        {
            public string valuetype;
            public List<Dictionary<string, object>> values;
            public double count;
        }
    
        public class FreebaseTopic
        {
            public string id { get; set; }
            public Dictionary<string, ValueSet> property { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var restClient = new RestClient("https://www.googleapis.com");
    
                var restRequest = new RestRequest("freebase/v1/topic/m/0jdh5");
    
                var response = restClient.Execute(restRequest);
    
                var result = JsonConvert.DeserializeObject<FreebaseTopic>(response.Content);
    
            }
        }
    }
