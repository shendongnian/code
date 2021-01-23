    BlockingCollection<int> sharedQueue = new BlockingCollection<int>();
    for (int i = 0; i < 10; i++)
    {
        sharedQueue.Add(i);
    }
    // CompleteAdding marks the queue as "complete for adding,"
    // meaning that no more items will be added.
    sharedQueue.CompleteAdding();
    int itemCount= 0;
    Task[] tasks = new Task[2];
    for (int i = 0; i < tasks.Length; i++)
    {
        // create the new task
        tasks[i] = new Task(() =>
        {
            foreach (var queueElement in sharedQueue.GetConsumingEnumerable())
            {
                DateTime dt = DateTime.Now;
                Console.WriteLine("Item " + itemCount + "processed by " 
                    + Task.CurrentId + " Time: " + dt.Hour + ":" + dt.Minute + ":" + dt.Second);
                Interlocked.Increment(ref itemCount);   
                if (Task.CurrentId == 1) 
                    Thread.Sleep(2000);
                else 
                    Thread.Sleep(3000);                       
            }
        });
        // start the new task
        tasks[i].Start();
    }
