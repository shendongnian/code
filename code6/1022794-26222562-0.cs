    var myType = typeof(Custom1);
                ReadPropertiesRecursive(myType);
    private static void ReadPropertiesRecursive(Type type)
            {
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                    {
                        Console.WriteLine("test");
                    }
                    if (property.PropertyType.IsClass)
                    {
                        ReadPropertiesRecursive(property.PropertyType);
                    }
                }
            }
