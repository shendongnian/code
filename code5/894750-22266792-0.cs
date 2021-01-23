    public IEnumerable<T> GetItemsAndCollectionsAsItems<T>(params object[] itemsAndCollections)
    {
        var result = new List<T>();
        foreach (var itemOrCollection in itemsAndCollections)
        {
            var collection = itemOrCollection as IEnumerable<T>;
            if (collection == null)
            {
                result.Add((T)itemOrCollection);
            }
            else
            {
                result.AddRange(collection);
            }
        }
        return result;
    }
