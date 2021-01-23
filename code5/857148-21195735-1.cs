    //by default, BlockingCollection will use ConcurrentQueue
    BlockingCollection<int> coll = new BlockingCollection<int>();
    
    coll.Add(1);
    coll.Add(2);
    coll.CompleteAdding();
    
    int item;
    
    if (coll.TryTake(out item, -1))
    {
    	Console.WriteLine(item);
    }
    
    if (coll.TryTake(out item, -1))
    {
    	Console.WriteLine(item);
    }
    
    if (coll.TryTake(out item, -1))
    {
    	//this won't get hit
    }
    else
    {
    	Console.WriteLine("TryTake returned false!");
    }
