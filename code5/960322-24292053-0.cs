    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RestSharp;
    using RestSharp.Deserializers;
    
    namespace JSONRestTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Requesting data...");
    
                //create new RestSharp Client and tell it the Host
                RestClient client = new RestClient("http://blockchain.info");
    
                //Tell it the path and any variables if needed
                RestRequest request = new RestRequest("/ticker", Method.GET);
                //request.AddParameter("myParameter", myVariable);
    
                //Tell RestSharp to expect JSON
                request.RequestFormat = DataFormat.Json;
    
                //Execute the request
                IRestResponse response = client.Execute(request);
    
                //Create a JSON Deserializer
                JsonDeserializer deserial = new JsonDeserializer();
    
                //Deserialize to a Dictionary Object 
                Dictionary<string, Rate> jsonObj = deserial.Deserialize<Dictionary<string, Rate>>(response);
                
                //Loop through the Dictionary
                foreach (KeyValuePair<string, Rate> currency in jsonObj)
                {
                    Console.WriteLine(currency.Key + " Rate: " + currency.Value.last.ToString());
                }
    
                Console.WriteLine("Done...");            
            }
        }
    
        public class Rate
        {        
            public float _15m { get; set; }
            public double last { get; set; }
            public double buy { get; set; }
            public double sell { get; set; }
            public string symbol { get; set; }
        }      
    }
