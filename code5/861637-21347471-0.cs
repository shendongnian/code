      interface IComplexDataContainer<TKey, TValue>
        : IEnumerable<KeyValuePair<TKey,TValue>>
      {
        TValue this[TKey index] { get; set; }
      }
    
      class MyComplexDataContainer<TKey, TValue>
        : IComplexDataContainer<TKey, TValue>
      {
        IDictionary<TKey, TValue> hiddenHelper { get; set; }
    
        public MyComplexDataContainer()
        {
          hiddenHelper = new Dictionary<TKey, TValue>();
        }
    
        // delegate all of the work to the hidden dictionary
        public TValue this[TKey index]
        {
          get
          {
            return hiddenHelper[index];
          }
          set
          {
            hiddenHelper[index] = value;
          }
        }
    
        // Just delegate the IEnumerable interface to your hidden dictionary
        // or any other interface you want your class to implement
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
          return hiddenHelper.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
          return GetEnumerator();
        }
      }
