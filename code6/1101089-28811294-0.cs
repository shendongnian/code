    class IndexedObject<TValue> : IEqualityComparer<TValue> {
      public TValue Value { get; private set; } 
      public int Index { get; private set; }
      public IndexedObject(TValue value, int index) {
        Value = value;
        Index = index;
      }
      // Forward  IEqualityComparer<TValue> to Value
    }
