    public void Update(TEntity entity)
    {
        // First the original entity is retrieve by searching the key, this item is then removed from the collection
        // Then a new item is being added to the collection.
        var original = Find(_keyProperties.Select(e => e.GetValue(entity)).ToArray());
        Detach(original);
        _entitiesCollection.Add(entity);
    }
