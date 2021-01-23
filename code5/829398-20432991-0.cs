    public static void DoWork()
    {
        // imitation of geting message from some queue
        int message = GetMessageFromQueue();
        // Run new task to work with next message
        Task.Factory.StartNew(() => DoWork());
        // do some work
    }
