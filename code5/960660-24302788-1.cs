    // This assumes it really is just a List<T>...
    Type elementType = list.GetType().GetGenericArguments()[0];
    PropertyInfo property = elementType.GetProperty(displayMember);
    List<object> displayValues = list.Select(v => property.GetValue(v, null))
                                     .ToList();
