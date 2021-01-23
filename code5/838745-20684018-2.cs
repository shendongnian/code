    public static void Func(out MyClass b)
    {
       b = new MyClass();
    }
    
    ...
    MyClass b;
    Func(out b);
    Assert.IsNotNull(b);
