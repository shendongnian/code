    public void doSomething(Type _type)
    {
        this.GetType().GetMethod("doSomething", Type.EmptyTypes)
            .MakeGenericMethod(_type)
            .Invoke(this, null);
    }
