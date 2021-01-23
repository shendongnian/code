    private void MySynchronousMethodLikeDisposeForExample()
    {
        using (NoSynchronizationContextScope.Enter())
        {
            MyAsyncMethod().Wait();
        }
    }
