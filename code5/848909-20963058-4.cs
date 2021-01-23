    class CustomResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, 
                                            MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType == typeof(Problematic) && 
                property.PropertyName == "Offender")
            {
                property.ShouldSerialize = instanceOfProblematic => false;
            }
            return property;
        }
    }
