    public static class TypeExtension
    {
        public static string[] GetStaticStrings(this Type type)
        {
            return type
                     .GetFields(BindingFlags.Public | BindingFlags.Static)
                     .Where(field => field.FieldType == typeof(string))
                     .Select(field => (string)field.GetValue(null))
                     .ToArray();
        }
    }
