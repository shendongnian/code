    public static class ClassPropTextSearch
    {
        private static Dictionary<Type, List<PropertyInfo>> _stringProperties =
            new Dictionary<Type, List<PropertyInfo>>();
        public static bool Match<T>(T item, string searchTerm)
        {
            // null checking skipped...
            if (!_stringProperties.ContainsKey(typeof(T)))
            {
                // Retrieve and store the list of string properties of the input's type
                var stringProperties = typeof(T)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty)
                    .Where(p => p.PropertyType == typeof(string))
                    .ToList();
                _stringProperties.Add(item.GetType(), stringProperties);
            }
            return _stringProperties[typeof(T)]
                .Select(prop => prop.GetValue(item, null))
                .OfType<string>()
                .Any(value => value != null && value.ToLower().Contains(searchTerm.ToLower()));
        }
    }
