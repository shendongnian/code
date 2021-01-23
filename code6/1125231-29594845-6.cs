    private static Disposable disposable;
    private static Disposable MakeDisposable()
    {
        if ( disposable == null )
            disposable = new Disposable();
        return disposable;
    }
    private static void DisposeDisposable()
    {
        // elided
    }
