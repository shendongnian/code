    public static void Func(out MyClass b)
    {
       b = new MyClass();
    }
    
    ...
    MyClass b;
    Func(ref b);
    Assert.IsNotNull(b);
