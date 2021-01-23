    public void Foo (string paramA, object valueA)
    {
       this.Foo(new Dictionary<string, object> { { paramA, valueA } });
    }
    
    public void Foo (string paramA, object valueA, string paramB, object valueB)
    {
       this.Foo(new Dictionary<string, object> { { paramA, valueA },{ paramB, valueB } });
    }
    
    public void Foo (Dictionary<string, object> args)
    {
    }
