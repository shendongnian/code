    public class SampleClass<T, TCollection> where TCollection : List<T>
    {
      private readonly List<T> _collection;
      
      public SampleClass() : this(new List<T>()) { }
      public SampleClass(TCollection collection)
      {
        _collection = collection;
      }
    }
