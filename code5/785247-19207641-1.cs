    public virtual void Add(T item)
    {
        if (predicate != null && !predicate(item))
        {        
            throw new AppExcpetion("Add non-matching element.");
        }
        mDbSet.Add(item);
    }
