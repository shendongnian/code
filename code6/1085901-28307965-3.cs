    private void MySynchronousMethodLikeDisposeForExample()
    {
        using (new NoSynchronizationContextScope())
        {
            MyAsyncMethod().Wait();
        }
    }
