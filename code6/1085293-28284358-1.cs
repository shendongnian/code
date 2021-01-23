    static void Main(string[] args)
    {
        TaskHelper helper = new TaskHelper();
        helper.StartProcessingAsync().Wait();
    }
