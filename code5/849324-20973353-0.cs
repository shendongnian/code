    static void Main(string[] args)
    {
        BlockingCollection<int> bc = new BlockingCollection<int>();
        ManualResetEvent emptyEvent = new ManualResetEvent(false);
        Thread newThread = new Thread(() => BackgroundProcessing(bc, emptyEvent));
        newThread.Start();
        //wait for the collection to be empty or the timeout to be reached.
        emptyEvent.WaitOne(1000);
    
    }
    static void BackgroundProcessing(BlockingCollection<int> collection, ManualResetEvent emptyEvent)
    {
        while (collection.Count > 0 || !collection.IsAddingCompleted)
        {
            int value = collection.Take();
            Thread.Sleep(100);
        }
        emptyEvent.Set();
    }
