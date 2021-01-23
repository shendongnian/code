    void Save<T>(List<T> entities, T entity)
        where T: INamedEntity
    {
        // searching if the object does exist:
        var isExists = entities.Any(e => e.Name == entity.Name);
    
        // after some other tests, the object is added to the list:
        entities.Add(entity.Clone());
    }
