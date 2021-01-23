    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public class myClass
    {
        public string ID { get; set; }
        public string KEY1 { get; set; } 
        public List<string> CATEG { get; set; } 
    }
    
    public class ESObject1
    {
        [JsonProperty("EVT")]
        public List<myClass> EVT { get; set; }
    }
    
    public class ESObject0
    {
        [JsonProperty("EVTS")]
        public ESObject1 EVTS { get; set; }
    }
    
    
    class Program
    {
        static void Main()
        {
            string json = 
            @"{
                ""EVTS"": {
                    ""EVT"": [
                        {
                            ""ID"": ""123456"",
                            ""KEY1"": ""somekey"",
                            ""CATEG"": [
                                ""cat1"",
                                ""cat2"",
                                ""cat3""
                            ]
                        }
                    ]
                }
            }";
    
            ESObject0 globalobject = JsonConvert.DeserializeObject<ESObject0>(json);
            foreach (string item in globalobject.EVTS.EVT[0].CATEG)
            {
                Console.WriteLine(item);
            }
        }
    }
