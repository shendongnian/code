    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
      private IDictionary<TKey, TValue> _dictionary = //...
      public event EventHandler<DictionaryChangedArgs> OnAdded;
      public ObservableDictionary()
      {
        _dictionary = new Dictionary<TKey, TValue>();
      }    
      //wrap an existing dictionary
      public ObservableDictionary(IDictionary<Tkey, TValue> dictionary)
      {
        _dictionary = dictionary;
      }   
      public void Add(TKey key, TValue val) {
        _dictionary.Add(key, value);
        
        if(OnAdded != null)
          OnAdded(new DictionaryChangedArgs(key, value));    
      }
    
    }
