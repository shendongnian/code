    private static void TestPolymorphismWithDisposable()
    {
        IFoo foo = DataAccessFactory.Resolve();
        
        using(foo as IDisposable)
        {
            foo.Invoke(); //This is always executed regardless of whether IDisposable is implemented
            //Dispose is called if IDisposable was implemented
        }
    }
