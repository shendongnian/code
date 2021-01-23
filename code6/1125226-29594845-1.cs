    private static disposable;
    private static Disposable MakeDisposable()
    {
        disposable = new Disposable();
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
