    public void createList(Type t)
    {
        this.GetType()
            .GetMethod("createList", Type.EmptyTypes)
            .MakeGenericMethod(t)
            .Invoke(this, null);
    }
