    class CustomResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type,
                           Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            if (type == typeof(Your_Class))
            {
                JsonProperty prop = 
                    props.Where(p => p.PropertyName == "EndDate")
                         .FirstOrDefault();
                if (prop != null)
                {
                    prop.Converter = 
                         new IsoDateTimeConverter { DateTimeFormat = "dd-MM-yyyy" };
                }
            }
            return props;
        }
    }
