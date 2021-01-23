    TaskManager<Task<int>> tasks = new TaskManager<Task<int>>();
    
    Task<int> task = new Task<int>(i => 3 + 4, WriteIntToScreen); // WriteIntToScreen is a fake function to use as the callback
    
    tasks.Enqueue(task);
    
    tasks.OnTaskDequeued += delegate 
    { 
       tasks.Enqueue(task);
       tasks.Dequeue.Invoke();
    };
    
    // start the routine with
    tasks.Dequeue.Invoke(); // you call do some async threading here with BeginInvoke or something but I am not gonna write all that out as it will be pages...
