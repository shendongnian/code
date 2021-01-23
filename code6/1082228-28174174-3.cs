    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    
    namespace ConsoleApplication
    {
        [DataContract]
        public class Data
        {
            [DataMember]
            public List<string[]> data { get; set; }
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                string jsonTxt = "{data:[[\"1.00\",\"1.00\"],[\"0.60\",\"0.60\"],[\"0.40\",\"0.40\"]]}";
                var deserialized = JsonConvert.DeserializeObject<Data>(jsonTxt);
    
                //Use this if you don't want to use DataContract, but you will have to reference Newtonsoft.Json.Linq
                List<string[]> fullDeserialized = JsonConvert.DeserializeObject<List<string[]>>(JObject.Parse(jsonTxt)["data"].ToString());
            }
        }
    }
