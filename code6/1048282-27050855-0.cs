    BlockingCollection<YourData> _collection = new BlockingCollection<YourData>();
    
    public void ProcessInParallel()
    {
        //This starts up your workers, it will create the number of cores you have - 1 workers.
        var tasks = new List<Task>();
        for(int i = 0; i < Environment.NumberOfLogicalCores - 1; i++)
        {
            var task = Task.Factory.StartNew(DataProcessorLoop, TaskCreationOptions.LongRunning);
            tasks.Add(task);
        }
    
        //This function could be done in parallel too, _collection.Add is fine with multiple threads calling it.
        foreach(YourData data in GetYourDataFromTheNetwork())
        {
            //Put data in to the collection, the first worker available will take it.
            _collection.Add(data);
        }
    
        //Let the consumers know you will not be adding any more data.
        _collection.CompleteAdding();
    
        //Wait for all of the worker tasks to drain the collection and finish.
        Task.WaitAll(tasks);
    }
    
    private void DataProcessorLoop()
    {
        //this will pull data from the collection of work to do, when there is no work to do
        //it will block until more work shows up or CompleteAdding is called.
        foreach(YourData data in _collection.GetConsumingEnumerable())
        {
            CrunchData(data)
        }
    }
