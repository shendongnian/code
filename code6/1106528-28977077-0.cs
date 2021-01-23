    public void Foo<T>(T data)
    {
        Type t = typeof(T);
        if(t.IsArray)
        {
            int length = ((Array)(object)data).Length;
        }
    }
