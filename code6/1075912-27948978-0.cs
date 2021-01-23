    // Construct started tasks
    Task[] tasks = new Task[100];
    for (int i = 0; i < 100; i++)
    {
        //action is your method as a delegate
        tasks[i] = Task.Factory.StartNew(action);
    }
    Task.WaitAll(tasks);
    FireHundredComplete(); //Invoke your event
