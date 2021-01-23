    public IAsyncResult SayHello(AsyncContext context)
    {
         // start a new async operation and return the IAsyncResult
    }
    
    void RealWork(AsyncContext context)
    {
        context.SetValue("some thing");
    }
