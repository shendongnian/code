    private static void HigherOrderFoo(Delegate foo, params object[] list)
    {
        var bar - foo.DynamicInvoke(list);
    }
    private static void Bar()
    { 
        HigherOrderFoo((Func<int, int>)Baz, 10);
    }
    private static int Baz(int val)
    {
        return val * val;
    }
