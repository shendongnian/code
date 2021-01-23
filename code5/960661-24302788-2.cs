    // This assumes it really is just a List<T>...
    IEnumerable list = (IEnumerable) dataSource;
    Type elementType = list.GetType().GetGenericArguments()[0];
    PropertyInfo property = elementType.GetProperty(displayMember);
    List<object> displayValues = list.Cast<object>()
                                     .Select(v => property.GetValue(v, null))
                                     .ToList();
