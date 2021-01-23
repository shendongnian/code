    private static void HigherOrderFoo(Delegate foo)
    {
        var returnVal = foo.DynamicInvoke(null);
    }
    
    private static void Bar()
    {
        HigherOrderFoo((Func<int>)(() => 10));
    }
