    class X
    {
       private List<int> _cache;
    
       public void UpdateCache(IEnumerable<int> items)
       {
         _cache = items.ToList();
       }
    
       public ICollection<T> Cache
       {
          get{ return _cache; }
       }
       //even better
       public ReadOnlyCollection<T> Items
       {
          get { return new ReadonlyCollection(_cache); }
       }
    }
