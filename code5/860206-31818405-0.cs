    protected void UpdateManyToMany<T>(YourDBContext db, ICollection<T> collection, List<int> idList) where T : class
    {
      //update a many to many collection given a list of key IDs
      collection.Clear();      
      var source = db.Set<T>();
      if (idList != null)
      {
        foreach (int i in idList)
        {
          var record = source.Find(i);
          collection.Add(record);
        }
      }
    }
