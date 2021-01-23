    private static void ReadPropertiesRecursive(Type type, IEnumerable<Type> visited)
    {
        foreach (PropertyInfo property in type.GetProperties())
        {
            if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
            {
                Console.WriteLine("test");
            }
            else if (property.PropertyType.IsClass && !visited.Contains(property.PropertyType))
            {
                ReadPropertiesRecursive(property.PropertyType, visited.Union(new Type[] { property.PropertyType }));
            }
        }
    }
