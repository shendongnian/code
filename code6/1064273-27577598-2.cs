    public static class ResourceHelper
    {
        public static PropertyInfo [] GetStaticPropertiesOfType<TValue>(Type type)
        {
            return type
              .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
              .Where(p => typeof(TValue).IsAssignableFrom(p.PropertyType) && p.GetIndexParameters().Length == 0 && p.GetGetMethod(true) != null)
              .ToArray();
        }
    }
