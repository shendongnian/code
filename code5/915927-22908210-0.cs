    public static class FullTextSearch<T>
    {
        private List<Func<T, string>> _properties;
        static FullTextSearch()
        {
            _properties = GetPropertyFunctions<T>().ToList();
        }
        public bool Match(T item, string searchTerm)
        {
            bool match = _properties.Select(prop => prop(item)).Any(value => value != null && value.ToLower().Contains(searchTerm.ToLower()));
            return match;
        }
    }
