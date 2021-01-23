    private static void Main(string[] args)
    {
        int highPriorityMaxConcurrancy = 1
        QueuedTaskScheduler qts = new QueuedTaskScheduler();
        var highPriortiyScheduler = qts.ActivateNewQueue(0);
        var lowPriorityScheduler = qts.ActivateNewQueue(1);
        
        BlockingCollection<HttpRequestWrapper> fileRequest= new BlockingCollection<Foo>();
        BlockingCollection<HttpRequestWrapper> commonRequest= new BlockingCollection<Foo>();
        List<Task> processors = new List<Task>(2);
        processors.Add(Task.Factory.StartNew(() =>
        {
            Parallel.ForEach(fileRequest.GetConsumingPartitioner(),  //.GetConsumingPartitioner() is also from ParallelExtensionExtras, it gives better performance than .GetConsumingEnumerable() with Parallel.ForEeach(
                             new ParallelOptions() { TaskScheduler = highPriortiyScheduler, MaxDegreeOfParallelism = highPriorityMaxConcurrancy }, 
                             ProcessWork);
        }, TaskCreationOptions.LongRunning));
        processors.Add(Task.Factory.StartNew(() =>
        {
            Parallel.ForEach(commonRequest.GetConsumingPartitioner(), 
                             new ParallelOptions() { TaskScheduler = lowPriorityScheduler}, 
                             ProcessWork);
        }, TaskCreationOptions.LongRunning));
        //Add some work to do here to the fileRequest or commonRequest collections
        //Lets the blocking collections know we are no-longer going to be adding new items so it will break out of the `ForEach` once it has finished the pending work.
        fileRequest.CompleteAdding();
        commonRequest.CompleteAdding();
        //Waits for the two collections to compleatly empty before continueing
        Task.WaitAll(processors.ToArray());
    }
    private static void ProcessWork(HttpRequestWrapper request)
    {
        //...
    }
