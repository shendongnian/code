    public static class ClassPropTextSearch
    {
        private static Dictionary<Type, List<PropertyInfo>> _stringProperties =
            new Dictionary<Type, List<PropertyInfo>>();
    
        public static bool Match(object item, string searchTerm)
        {
            return PropertiesMatch(item, searchTerm).Any();
        }
    
        public static string FirstPropMatch(object item, string searchTerm)
        {
            var prop = PropertiesMatch(item, searchTerm).FirstOrDefault();
            return prop != null ? prop.Name : string.Empty;
        }
    
        private static IEnumerable<PropertyInfo> PropertiesMatch(object item, string searchTerm)
        {
            // null checking skipped...
    
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
                .Where(prop => prop.GetValue(item, null) != null &&
                    ((string)prop.GetValue(item, null)).ToLower().Contains(searchTerm.ToLower()));
        }
    }
