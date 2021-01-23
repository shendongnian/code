    static void Main(string[] args)
    {
        TaskHelper helper = new TaskHelper();
        AsyncContext.Run(() => helper.StartProcessingAsync());
    }
