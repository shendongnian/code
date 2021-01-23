    // To create your Queue
    ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
    // To add objects to your Queue
    queue.Enqueue("foo");
    // To deque items from your Queue    
    String bar;
    queue.TryDequeue(out bar);
    
    // To loop a process until your Queue is empty
    while(!queue.IsEmpty)
    {
        String bar;
        queue.TryDequeue(out bar);
    }
     
