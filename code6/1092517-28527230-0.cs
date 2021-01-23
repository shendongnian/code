    class Dummy<T> { }
    
    static void Foo()
    {
       InvokeIsolated<string, string>();
    }
    
    static void InvokeIsolated<T1, T2>()
    {
       AppDomain appDomain = AppDomain.CreateDomain("testDomain");
       appDomain.DoCallBack(new WrapperFunc<T1, T2, Dummy<T2>>(() => MyDoCallBack<T1, T2>()));
    }
    
    delegate void WrapperFunc<T1, T2, TDummy>()
    
    static void MyDoCallBack<T1, T2>() {}
