    public class ReadonlyJsonDefaultContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);
            if (!prop.Writable)
            {
                var property = member as PropertyInfo;
                if (property != null)
                {
                    var hasPrivateSetter = property.GetSetMethod(true) != null;
                    prop.Writable = hasPrivateSetter;
                    if (!prop.Writable)
                    {
                        var privateField = member.DeclaringType.GetRuntimeFields().FirstOrDefault(x => x.Name.ToLower().Equals("_" + prop.PropertyName.ToLower()));
                        
                        if (privateField != null)
                        {
                            var originalPropertyName = prop.PropertyName;
                            prop = base.CreateProperty(privateField, memberSerialization);
                            prop.Writable = true;
                            prop.PropertyName = originalPropertyName;
                            prop.UnderlyingName = originalPropertyName;
                            prop.Readable = true;
                        }
                    }
                }
            }
            return prop;
        }
    }
