    Barrier barrier = new Barrier(2); // 2 = #threads participating.
    bool complete = false;
    // Start tasks
    Task task_1 = Task.Factory.StartNew(() =>
    {
        Console.WriteLine("1");
        barrier.SignalAndWait(); // Wait for task 2 to catch up.
        barrier.SignalAndWait(); // Wait for task 2 to print "2" and set complete = true.
        if (complete)
        {
            Console.WriteLine("3");
        }
    });
    Task task_2 = Task.Factory.StartNew(() =>
    {
        barrier.SignalAndWait(); // Wait for task 1 to print "1".
        Console.WriteLine("2");
        complete = true;
        barrier.SignalAndWait(); // Wait for task 1 to read complete as true.
    });
    task_2.Wait();
