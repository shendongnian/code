    public List<MyType> Get(List<int> idsToRead)
    {
        Dictionary<int, MyType> localCachedDictionary = CachedDictionary;
        if (localCachedDictionary == null)
            localCachedDictionary = new Dictionar<int, MyType>();
        List<int> idsNotCached = idsToRead.Except<int>(localCachedDictionary.Keys.ToList<int>()).ToList<int>();
        if (idsNotCached.Count > 0)
        {
            //Exception stack trace points to next line:
            MyTypeCollection DBitems = BusinessLayer.StaticLoadFromDB(idsNotCached); 
            lock (localCachedDictionary)
            {
                foreach (MyType item in DBitems)
                    if (!localCachedDictionary.ContainsKey(item.ID))
                        localCachedDictionary.Add(item.ID, item);
            }
        }
        if (CachedDictionary == null)
            CachedDictionary = localCachedDictionary;
        return localCachedDictionary.Where(p => idsToRead.Contains(p.Key)).Select(p => p.Value).ToList<MyType>();
    }
