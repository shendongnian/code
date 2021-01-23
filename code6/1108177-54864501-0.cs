    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    namespace testJsonDeserializer
    {
        class Program
        {
            static void Main(string[] args)
            {
                // this operator has the password set to meow. 
                Operator originalOperator = new Operator
                {
                    OperatorGuid = Guid.Parse("3bb1dc84-2963-4921-a567-fb2e7475623d"),
                    UserName = "noortje@peterhuppertz.net",
                    Password = "meow",
                    PropertyThatWillBeNulled = "noortje@peterhuppertz.net",
                };
    
                // this json EXPLICITLY sets the PropertyThatWillBeNulled to null, but omits the Password property, making it null IMPLICITLY. 
                string json =
                    "{ \"OperatorGuid\":\"3bb1dc84-2963-4921-a567-fb2e7475623d\", \"UserName\": \"noortje@peterhuppertz.net\", \"Email\": null }";
                // What a PATCH would want for the target object is to leave implicit Nulls unchanged, but explicit nulls set to null. 
    
                Operator patchedOperator = JsonConvert.DeserializeObject<Operator>(json);
                // At this stage, our patched operator has the password set to null. We do not want that; we want to keep whatever is stored in originalOperator
    
                Operator opToStore = MapJsonToOperator(patchedOperator, originalOperator, json);
    
                Console.WriteLine("Our patched operator:");
                Console.WriteLine($"Guid: {opToStore.OperatorGuid}");
                Console.WriteLine($"UserName: {opToStore.UserName}");
                Console.WriteLine($"Password: {opToStore.Password}");
                Console.WriteLine($"Email: {opToStore.PropertyThatWillBeNulled}");
                Console.ReadKey();
            }
    
            private static Operator MapJsonToOperator(Operator source, Operator original, string json)
            {
                Operator result = new Operator
                {
                    OperatorGuid = source.OperatorGuid,
                    UserName = source.UserName != null
                        // we check if the source property has a value, if so, we use that value.
                        ? source.UserName
                        // if it doesn't, we check the Json to see if the value is in there, explicitly set to NULL. If it is, we set it to NULL as well
                        : (IsNullValueExplicit(json, "UserName") ? null 
                            // if it is not in the json (making it implicitly null), we just leave the value as it was. 
                            : original.UserName),
                    PropertyThatWillBeNulled = source.PropertyThatWillBeNulled != null
                        ? source.PropertyThatWillBeNulled
                        : (IsNullValueExplicit(json, "Email") ? null : original.PropertyThatWillBeNulled),
                    Password = source.Password != null
                        ? source.Password
                        : (IsNullValueExplicit(json, "Password") ? null : original.Password),
                };
    
                return result;
            }
    
            static bool IsNullValueExplicit(string json, string fieldName)
            {
                JToken outer = JToken.Parse(json);
                JObject inner = outer.Value<JObject>();
                List<string> keys = inner.Properties().Select(p => p.Name).ToList();
                return keys.Contains(fieldName);
            }
        }
    
        public class Operator
        {
            public Guid OperatorGuid { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string PropertyThatWillBeNulled { get; set; }
        }
    }
