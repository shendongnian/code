    public static class ClassPropTextSearch
    {
        private static Dictionary<Type, List<PropertyInfo>> _stringProperties =
            new Dictionary<Type, List<PropertyInfo>>();
        public static bool Match(object item, string searchTerm)
        {
            // Skip null checking ...
            if (!_stringProperties.ContainsKey(item.GetType()))
            {
                // Retrieve and store the list of string properties of the input's type
                var stringProperties = item.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty)
                    .Where(p => p.PropertyType == typeof(string))
                    .ToList();
                _stringProperties.Add(item.GetType(), stringProperties);
            }
            return _stringProperties[item.GetType()]
                .Select(prop => prop.GetValue(item, null))
                .OfType<string>()
                .Any(value => value != null && value.ToLower().Contains(searchTerm.ToLower()));
        }
    }
