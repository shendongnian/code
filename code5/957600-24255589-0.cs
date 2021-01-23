    public static class WithCustomMappings
    {
        public static Func<Type, IEnumerable<Type>> AggregateMappings(params Func<Type, IEnumerable<Type>>[] mappings)
        {
            return type =>
            {
                var mappedTypes = new List<Type>();
                foreach (var mapping in mappings)
                    mappedTypes.AddRange(mapping(type));
                return mappedTypes.Distinct();
            };
        }
        public static Func<Type, IEnumerable<Type>> FromAllAbstractBaseClasses 
        {
            get
            {
                return type =>
                {
                    var abstractBaseTypes = new List<Type>();
                    var baseType = type.BaseType;
                    while (baseType != null)
                    {
                        if (baseType.IsAbstract)
                            abstractBaseTypes.Add(baseType);
                        baseType = baseType.BaseType;
                    }
                    return abstractBaseTypes;
                };
            }
        }
    }
