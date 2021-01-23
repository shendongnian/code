    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    class CustomResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            foreach (JsonProperty prop in properties)
            {
                if (prop.PropertyType == typeof(Foo))
                {
                    prop.ShouldSerialize = obj => 
                    {
                        Foo foo = (Foo)type.GetProperty(prop.PropertyName).GetValue(obj);
                        return foo != null && foo.Enabled;
                    };
                }
            }
            return properties;
        }
    }
