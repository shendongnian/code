    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    class Program
    {
        static void Main()
        {
            string json = "{'results':[{'SwiftCode':'','City':'','BankName':'Deutsche    Bank','Bankkey':'10020030','Bankcountry':'DE'},{'SwiftCode':'','City':'10891    Berlin','BankName':'Commerzbank Berlin (West)','Bankkey':'10040000','Bankcountry':'DE'}]}";
    
            var resultsArray = AllChildren(JObject.Parse(json))
                .First(c => c.Type == JTokenType.Array && c.Path.Contains("results"));
    
            foreach (JObject result in resultsArray) {
                foreach (JProperty property in result.Properties()) {
                    // do something with the property belonging to result
                }
            }
        }
        // recursively yield all children of json
        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children()) {
                yield return c;
                foreach (var cc in AllChildren(c)) {
                    yield return cc;
                }
            }
        }
    }
