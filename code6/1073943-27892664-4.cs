    [System.AttributeUsage(AttributeTargets.Property)]
    public class JsonPreferDerivedPropertyAttribute : System.Attribute
    {
    }
    public class PreferDerivedPropertyContractResolver : DefaultContractResolver
    {
        static PropertyInfo GetDerivedPropertyRecursive(Type objectType, Type stopType, PropertyInfo property)
        {
            var parameters = property.GetIndexParameters().Select(info => info.ParameterType).ToArray();
            for (; objectType != null && objectType != stopType; objectType = objectType.BaseType)
            {
                var derivedProperty = objectType.GetProperty(
                    property.Name,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, property.PropertyType,
                    parameters,
                    null);
                if (derivedProperty == null)
                    continue;
                if (derivedProperty == property)
                    return derivedProperty;  // No override.
                if (derivedProperty.GetCustomAttribute<JsonPreferDerivedPropertyAttribute>() != null)
                    return derivedProperty;
            }
            return null;
        }
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var list = base.GetSerializableMembers(objectType);
            for (int i = 0; i < list.Count; i++)
            {
                var property = list[i] as PropertyInfo;
                if (property == null)
                    continue;
                if (property.DeclaringType != objectType)
                {
                    var derivedProperty = GetDerivedPropertyRecursive(objectType, property.DeclaringType, property);
                    if (derivedProperty == null || derivedProperty == property)
                        continue;
                    if (derivedProperty != property 
                        && (property.GetGetMethod(true) == null || derivedProperty.GetGetMethod(true) != null)
                        && (property.GetSetMethod(true) == null || derivedProperty.GetSetMethod(true) != null))
                    {
                        list[i] = derivedProperty;
                    }
                }
            }
            return list;
        }
    }
