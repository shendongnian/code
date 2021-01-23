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
                var converter = new IsoDateTimeConverter();
                converter.DateTimeFormat = attr.DataFormatString;
                property.Converter = converter;
            }
            return property;
        }
    }
