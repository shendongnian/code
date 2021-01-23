    var bb = new BatchBlock<string>(10);
    var ab = new ActionBlock<string[]>(msgArray=>{ 
        foreach(var msg in msgArray) 
            Console.Writeline(msg);
    });
    
    bb.LinkTo(ab);
    
    foreach (string value in blockingCollection.GetConsumingEnumerable())
    {
          bb.Post(value);
    }
