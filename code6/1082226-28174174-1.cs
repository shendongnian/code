    using Newtonsoft.Json;
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
            }
        }
    }
