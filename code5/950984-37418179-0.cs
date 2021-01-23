    public void UpdateCollection<TCollection, TKey>(
        DbContext context, IList<TCollection> databaseCollection, 
        IList<TCollection> detachedCollection, 
        Func<TCollection, TKey> keySelector) where TCollection: class where TKey: IEquatable<TKey>
    {
        var databaseCollectionClone = databaseCollection.ToArray();
        foreach (var databaseItem in databaseCollectionClone)
        {
            var detachedItem = detachedCollection.SingleOrDefault(item => keySelector(item).Equals(keySelector(databaseItem)));
            if (detachedItem != null)
            {
                context.Entry(databaseItem).CurrentValues.SetValues(detachedItem);
            }
            else
            {
                context.Set<TCollection>().Remove(databaseItem);
            }
        }
        foreach (var detachedItem in detachedCollection)
        {
            if (databaseCollectionClone.All(item => keySelector(item).Equals(keySelector(detachedItem)) == false))
            {
                databaseCollection.Add(detachedItem);
            }
        }
    }
