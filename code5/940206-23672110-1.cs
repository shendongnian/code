    private static Type GetCollectionType(IEnumerable collection)
    {
      Type type = collection.GetType();
      if (type.IsGenericType)
      {
        Type[] types = type.GetGenericArguments();
        if (types.Length == 1)
        {
          return types[0];
        }
        else
        {
          // Could be null if implements two IEnumerable
          return type.GetInterfaces().Where(t => t.IsGenericType)
            .Where(t => t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            .SingleOrDefault().GetGenericArguments()[0];
        }
      }
      else if (collection.GetType().IsArray)
      {
        return type.GetElementType();
      }
      // TODO: Who knows, but its probably not suitable to render in a table
      return null;
    }
