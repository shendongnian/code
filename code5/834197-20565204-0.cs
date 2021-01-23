    class ListComparisonResult<TKey>
    {
      public IList<TKey> NewKeys { get; private set; }
      public IList<TKey> OldKeys { get; private set; }
      public IList<TKey> ChangedKeys { get; private set; }
      
      public ListComparisonResult(IList<TKey> newKeys, IList<TKey> oldKeys, IList<TKey> changedKeys)
      {
        NewKeys = new ReadOnlyCollection<TKey>(newKeys);
        OldKeys = new ReadOnlyCollection<TKey>(oldKeys);
        ChangedKeys = new ReadOnlyCollection<TKey>(changedKeys);
      }
    }
    ListComparisonResult<TKey> GetChanges<TRow, TKey, TValues>(
      IEnumerable<TRow> collectionA, 
      IEnumerable<TRow> collectionB,  
      Func<TRow, TKey> keySelector, 
      Func<TRow, TValues> comparableValuesSelector)
    {
      var byId = new
      {
        A = collectionA.ToDictionary(keySelector),
        B = collectionB.ToDictionary(keySelector),
      };
    
      var sameIds = new HashSet<TKey>(byId.A.Keys.Where(byId.B.ContainsKey));
    
      var changedIds = (from id in sameIds
                        let a = byId.A[id]
                        let b = byId.B[id]
                        where !comparableValuesSelector(a).Equals(comparableValuesSelector(b))
                        select id).ToList();
      
      var oldIds = byId.A.Keys.Where(id => !byId.B.ContainsKey(id)).ToList();
      var newIds = byId.B.Keys.Where(id => !byId.A.ContainsKey(id)).ToList();
      return new ListComparisonResult<TKey>(newIds, oldIds, changedIds);
    }
