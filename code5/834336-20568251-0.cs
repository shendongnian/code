    public void ProcessRequest(HttpContext context)
    {
        var theProvider = (IServiceProvider)context;
        var theWorker = (HttpWorkerRequest)theProvider.GetService(typeof(HttpWorkerRequest));
        string theReferer = theWorker.GetKnownRequestHeader(HttpWorkerRequest.HeaderReferer);
        // Do something with referer here
    }
