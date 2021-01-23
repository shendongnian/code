     public static IQueryable<EntityObject> GetPageItemsOfCollection(IQueryable<EntityObject> collectionIQueryable, int startIndex, int pageSize)
    {
      if (collectionIQueryable == null)
        return null;
      return collectionIQueryable.Skip(startIndex).Take(pageSize);
    }
