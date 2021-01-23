    private static Disposable disposable = new Disposable();
    private static Disposable MakeDisposable()
    {
        return disposable;
    }
    private static void DisposeDisposable()
    {
        if ( _disposable != null )
        {
            _disposable.Dispose();
            _disposable = null;
        }
    }
