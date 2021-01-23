    public void Foo(string bar ) 
    {
        if (null == bar)
           throw new ArgumentNullExpcetion(bar, "bar");
    }
