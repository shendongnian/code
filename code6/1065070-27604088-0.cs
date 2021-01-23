    static IEnumerable<FieldInfo> GetDependencyProperties(Type type)
    {
         var dependencyProperties = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                           .Where(p => p.FieldType.Equals(typeof(DependencyProperty)));
         return dependencyProperties;
    }
