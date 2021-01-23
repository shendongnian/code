    public static class MyCollectionExtensions
    {
      public static MyCollection ToMyCollection(IEnumerable<MyType> collection) 
      {
          return collection as MyCollection ?? new MyCollection(collection);
      }
    }
