    private static void Main(string[] args)
    {
        int totalMaxConcurrancy = Environment.ProcessorCount;
        int highPriorityMaxConcurrancy = totalMaxConcurrancy / 2;
        if (highPriorityMaxConcurrancy == 0)
            highPriorityMaxConcurrancy = 1;
        QueuedTaskScheduler qts = new QueuedTaskScheduler(TaskScheduler.Default, totalMaxConcurrancy);
        var highPriortiyScheduler = qts.ActivateNewQueue(0);
        var lowPriorityScheduler = qts.ActivateNewQueue(1);
        
        BlockingCollection<Foo> highPriorityWork = new BlockingCollection<Foo>();
        BlockingCollection<Foo> lowPriorityWork = new BlockingCollection<Foo>();
        Task.Factory.StartNew(() =>
        {
            Parallel.ForEach(highPriorityWork.GetConsumingPartitioner(),  //.GetConsumingPartitioner() is also from ParallelExtensionExtras, it gives better performance than .GetConsumingEnumerable() with Parallel.ForEeach(
                             new ParallelOptions() { TaskScheduler = highPriortiyScheduler, MaxDegreeOfParallelism = highPriorityMaxConcurrancy }, 
                             ProcessWork);
        }, TaskCreationOptions.LongRunning);
        Task.Factory.StartNew(() =>
        {
            Parallel.ForEach(lowPriorityWork.GetConsumingPartitioner(), 
                             new ParallelOptions() { TaskScheduler = lowPriorityScheduler}, 
                             ProcessWork);
        }, TaskCreationOptions.LongRunning);
        //Add some work to do here to the highPriorityWork or lowPriorityWork collections
        //Lets the blocking collections know we are no-longer going to be adding new items so it will break out of the `ForEach` once it has finished the pending work.
        highPriorityWork.CompleteAdding();
        lowPriorityWork.CompleteAdding();
    }
    private static void ProcessWork(Foo work)
    {
        //...
    }
