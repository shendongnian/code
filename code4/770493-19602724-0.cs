    public class ConverterContractResolver : DefaultContractResolver
    {
         protected override IList<JsonProperty> CreateProperties(Type type, 
                       Newtonsoft.Json.MemberSerialization memberSerialization)
         {
             //filter the properties and return back the final list
         }
    }
