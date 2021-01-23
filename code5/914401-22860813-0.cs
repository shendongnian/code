    public class CustomDateTimeFormatResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            
            // skip if the property is not a DateTime
            if (property.PropertyType != typeof (DateTime))
            {
                return property;
            }
            var attr = (DisplayFormatAttribute)member.GetCustomAttributes(typeof(DisplayFormatAttribute), true).SingleOrDefault();
            if (attr != null)
            {
                // Add custom JsonConverter if there is a DisplayFormat attribute set on the property
                property.Converter = new CustomDateTimeFormatConverter(attr.DataFormatString);
            }
            return property;
        }
    }
