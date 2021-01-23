    using Newtonsoft.Json.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            string json = "{'results':[{'SwiftCode':'','City':'','BankName':'Deutsche Bank','Bankkey':'10020030','Bankcountry':'DE'},{'SwiftCode':'','City':'10891 Berlin','BankName':'Commerzbank Berlin (West)','Bankkey':'10040000','Bankcountry':'DE'}]}";
    
            var results = JObject
                .Parse(json)["results"]
                .Children<JObject>();
    
            foreach (JObject result in results) {
                foreach (JProperty property in result.Properties()) {
                    // do something with the property belonging to result
                }
            }
        }
    }
