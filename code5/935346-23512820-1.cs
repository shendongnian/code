    public virtual void Remove(TEntity entity)
    {
        if (!entity.Id.HasValue) {
            throw new Exception("Cannot remove " + entity + ", it has no ID");
        }
        ...
    }
