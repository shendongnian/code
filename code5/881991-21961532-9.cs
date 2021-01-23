    public static class UnityNamedInstance
    {
        public static string AttributeName(Type type)
        {
            var namedAttribute = type
                .GetCustomAttributes(typeof(UnityNamedInstanceAttribute), true)
                .FirstOrDefault()
                as UnityNamedInstanceAttribute;
            return namedAttribute != null ? namedAttribute.InstanceName : null;
        }
        public static string AttributeNameOrDefault(Type type)
        {
            return UnityNamedInstance.AttributeName(type) ?? WithName.Default(type);
        }
    }
