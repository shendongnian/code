    var obj = JsonConvert.DeserializeObject<Person>(
                json, 
                new JsonSerializerSettings { 
                        ContractResolver = new CustomContractResolver() 
                });
----
    public class CustomContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.Replace("_",""); 
        }
    }
