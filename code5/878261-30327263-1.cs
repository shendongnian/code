    // Automatic camel casing because I'm bored of putting [JsonProperty] on everything
    // See: http://harald-muehlhoff.de/post/2013/05/10/Automatic-camelCase-naming-with-JsonNET-and-Microsoft-Web-API.aspx#.Uv43fvldWCl
    public class CamelCase : CamelCasePropertyNamesContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member,
            MemberSerialization memberSerialization)
        {
            var res = base.CreateProperty(member, memberSerialization);
            var attrs = member.GetCustomAttributes(typeof(JsonPropertyAttribute), true);
            if (attrs.Any())
            {
                var attr = (attrs[0] as JsonPropertyAttribute);
                if (res.PropertyName != null && attr.PropertyName != null)
                    res.PropertyName = attr.PropertyName;
            }
            return res;
        }
    }
