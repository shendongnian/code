    using System.Threading;
    IFoo a;
    public IFoo Foo
    {
        get
        {
            return LazyInitializer.EnsureInitialized(ref a, () => { /* load a */ });
        } 
    }
