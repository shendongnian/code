    private static Type GetCollectionType(IEnumerable collection)
    {
      Type type = collection.GetType();
      if (type.IsGenericType)
      {
        return type.GetInterfaces().Where(t => t.IsGenericType)
          .Where(t => t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
          .Single().GetGenericArguments().Last();
      }
      else if (collection.GetType().IsArray)
      {
        return type.GetElementType();
      }
      else
      {
            // Who knows?
            return null;
       }
    }
