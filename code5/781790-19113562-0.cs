    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
        if (e.NavigationMode == NavigationMode.Back)
        {
            ResetPageCache();
        }
    }
     
    private void ResetPageCache()
    {
        var cacheSize = ((Frame) Parent).CacheSize;
        ((Frame) Parent).CacheSize = 0;
        ((Frame) Parent).CacheSize = cacheSize;
    }
