    public namespace SomeNamespace 
    {
        public static class ColorHelper
        {
            public static IEnumerable<KeyValuePair<String, Color>> GetColors()
            {
                return typeof(Colors)
                    .GetProperties()
                    .Where(prop =>
                        typeof(Color).IsAssignableFrom(prop.PropertyType))
                    .Select(prop =>
                        new KeyValuePair<String, Color>(prop.Name, (Color)prop.GetValue(null)));
            }
        }
    }
