    public static TIEnumerable ToIEnumerable<TIEnumerable>(this IEnumerable<object> source)
    {
      var type = typeof(TIEnumerable);
      if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(IEnumerable<>))
        throw new ArgumentException("Wrong type arg: " + type, "TIEnumerable");
      var methOpen = typeof(Enumerable).GetMethod("Cast");
      var methConstructed = methOpen.MakeGenericMethod(type.GenericTypeArguments[0]);
      return (TIEnumerable)methConstructed.Invoke(null, new object[] { source, });
    }
