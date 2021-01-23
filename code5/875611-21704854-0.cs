    var bb = new BatchBlock<string>(10);
    var ab = new ActionBlock<string>(msg=>{Console.Writeline(msg);});
    
    bb.LinkTo(ab);
    
    foreach (string value in blockingCollection.GetConsumingEnumerable())
    {
          bb.Post(value);
    }
