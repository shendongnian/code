    public static class ClassPropertySearch
    {
        public static bool Match(Type itemType, string searchTerm)
        {
            bool match = _properties.Select(prop => prop(itemType)).Any(value => value != null && value.ToLower().Contains(searchTerm.ToLower()));
            return match;
        }
    
        private static List<Func<Type, string>> _properties;
    
        public static void FullTextSearchInit()
        {
            _properties = GetPropertyFunctions().ToList();
        }
    }
