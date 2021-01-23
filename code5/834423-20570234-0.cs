     public static class ListExtensions
    {
        public static IEnumerable<T> MatchWithAnyProperty<T, TK>(this IEnumerable<T> list, TK value)
        {
            var argType = typeof (TK);
            var properties = typeof(T).GetProperties().Where(x => x.PropertyType.IsAssignableFrom(argType));
          return  list.Where(item => properties.Any(prop =>
                {
                    var propertyValue = prop.GetValue(item, null);
                    if (value == null)
                        return propertyValue == null;
                    return propertyValue.Equals(value);
                }));
        }
    }
