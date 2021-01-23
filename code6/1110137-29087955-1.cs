        public class ShouldSerializeContractResolver : DefaultContractResolver
        {
            private Type myType;
            private List<string> propertiesNames;
            public ShouldSerializeContractResolver(Type type)
            {
                myType = type;
                this.propertiesNames =
                    type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Select(p => p.Name)
                    .ToList();
            }
            protected override JsonContract CreateContract(Type objectType)
            {
                if (objectType == myType)
                {
                    return CreateObjectContract(objectType);
                }
                return base.CreateContract(objectType);
            }
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);
                property.ShouldSerialize =
                    instance =>
                    {
                        return propertiesNames.Contains(property.PropertyName);
                    };
                return property;
            }
        }
