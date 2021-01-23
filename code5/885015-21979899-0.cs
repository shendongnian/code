    public virtual void Update(TEntity entity, // Entity to update
        IEnumerable<object> updatedSet, // Updated many-to-many relationships
        IEnumerable<object> availableSet, // Lookup collection
        string propertyName, // The name of the navigation property
        Expression<Func<TEntity, bool>> filter) // Filter for the first or default method
    {
        // Get the generic type of the set
        var type = updatedSet.GetType().GetGenericArguments()[0];
        // Get the previous entity from the database based on repository type
        var previous = Context.Set<TEntity>().Include(propertyName).FirstOrDefault(filter);
        /* Create a container that will hold the values of
            * the generic many-to-many relationships we are updating.
            */
        var values = CreateList(type);
        // For each object in the updated set...
        foreach (var obj in updatedSet)
        {
            /* ...find the existing entity in the database. This is to avoid
                * Entity Framework from creating new objects or throwing an
                * error because the object is already attached.
                */
            var value = (int)obj.GetType().GetProperty("Id").GetValue(obj, null);
            var entry = Context.Set(type).Find(value);
            values.Add(entry);
        }
        /* Get the collection where the previous many to many relationships
            * are stored and assign the new ones.
            */
        Context.Entry(previous).Collection(propertyName).CurrentValue = values;
    }
