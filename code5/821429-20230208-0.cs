    // create a blocking collection
    // the constructor will take an IProducerConsumerCollection
    // or it will use a ConcurrentQueue<T> by default if none is provided
    var blockingCollection = new BlockingCollection<String>();
    // generate items and add them to the collection
    Task.Factory.StartNew(() => {
        for (int i = 0; i < 100; i++) {
            blockingCollection.Add("value" + i);
        }
        // mark adding as complete so the foreach loops
        // below will exit when the collection is empty
        blockingCollection.AddingComplete();
    });
    // create worker 1 to process items
    Task.Factory.StartNew(() => {
        foreach (string value in blockingCollection.GetConsumingEnumerable()) {
            Console.WriteLine("Worker 1: " + value);
        }               
    });
    
    // create worker N to process items
    Task.Factory.StartNew(() => {
        foreach (string value in blockingCollection.GetConsumingEnumerable()) {
            Console.WriteLine("Worker N: " + value);
        }               
    });
