    public void Update<T>(T item) where T: Entity
    {
        // assume Entity base class have an Id property for all items
        var entity = _collection.Find(item.Id);
        if (entity == null)
        {
            return;
        }
    
        _context.Entry(entity).CurrentValues.SetValues(item);
    }
