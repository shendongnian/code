    ApiModel.JsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
    ApiModel.JsonSerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
    ApiModel.JsonSerializerSettings.ContractResolver = ApiModel.JsonContractResolver;
    
    internal class ApiModelContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override Newtonsoft.Json.Serialization.JsonProperty CreateProperty(System.Reflection.MemberInfo member, Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
    
            property.ShouldSerialize =
                instance =>
                {
                    var apiModel = instance as ApiModel;
    
                    var hasAttribute = apiModel.HasAttribute(property.PropertyName);
    
                    property.NullValueHandling = hasAttribute ? Newtonsoft.Json.NullValueHandling.Include : Newtonsoft.Json.NullValueHandling.Ignore;
    
                    return hasAttribute;
                };
    
            return property;
        }
    }
