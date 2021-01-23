    private static void TestPolymorphismWithDisposable()
    {
        using(IFoo foo = DataAccessFactory.Resolve())
        {
            foo.Invoke();
        }
    }
