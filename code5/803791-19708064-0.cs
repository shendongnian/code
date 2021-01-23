    if( valueFromRegistryIsAlwaysFalse)
    {
       DoStuff();
    }
    [System.Runtime.CompilerServices.MethodImpl(
        System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
    void DoStuff()
    {
       var A = new classA();
       A.method1();
    }
