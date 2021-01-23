    public void Bar<T>(T item)
    {
        if (typeof(T).IsClass)
            this.Foo((object) item);
    } 
