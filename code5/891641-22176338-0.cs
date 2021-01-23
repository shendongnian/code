    public HttpResponseMessage Put(HttpRequestMessage request)
    {
        var stream = GetStreamFromUploadedFile(request);
        // do something with the stream, then return something
    }
    private static Stream GetStreamFromUploadedFile(HttpRequestMessage request)
    {
        // Awaiting these tasks in the usual manner was deadlocking the thread for some reason.
        // So for now we're invoking a Task and explicitly creating a new thread.
        // See here: http://stackoverflow.com/q/15201255/328193
        IEnumerable<HttpContent> parts = null;
        Task.Factory
            .StartNew(() => parts = request.Content.ReadAsMultipartAsync().Result.Contents,
                            CancellationToken.None,
                            TaskCreationOptions.LongRunning,
                            TaskScheduler.Default)
            .Wait();
        Stream stream = null;
        Task.Factory
            .StartNew(() => stream = parts.First().ReadAsStreamAsync().Result,
                            CancellationToken.None,
                            TaskCreationOptions.LongRunning,
                            TaskScheduler.Default)
            .Wait();
        return stream;
    }
