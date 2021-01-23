    static class PropertyOptionsConvertor
    {
        private static Dictionary<string, PropertyOptions>() Mapping = new Dictionary<string, PropertyOptions>(StringComparer.OrdinalIgnoreCase)
        {
            { "on",    PropertyOptions.On },
            { "off",   PropertyOptions.Off },
            // other members...
        };
    
        public static bool GetOptions(string value, out PropertyOptions result)
        {
            if (Mapping.TryGetValue(value, out result))
            {
                return true;
            }
    
            result = default(PropertyOptions);
            return false;
        }
    }
