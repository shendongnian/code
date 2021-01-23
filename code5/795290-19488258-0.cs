        public static void GetAllSearchPropertiesWithOrderBy(Type type, ref List<PropertyInfo> result)
        {
            result = result ?? new List<PropertyInfo>();
            foreach (var propertyInfo in GetSearchPropertiesWithOrderBy(type))
            {
                result.Add(propertyInfo);
                GetAllSearchPropertiesWithOrderBy(propertyInfo.PropertyType, ref result);
            }
        }
