    private static void SomeMethod(int num)
    {
        var numbers = new List<int>();
    
        // create only one level 2 task for representation purpose
        for (var i = 0; i < 1; i++)
        {
            numbers.Add(i);
        }
    
        var tasks = new List<Task>();
    
        foreach (var number in numbers)
        {
            Console.WriteLine("Before start task: {0} - thread {1}", num, 
                                  Thread.CurrentThread.ManagedThreadId);
    
            var numberSafe = number;
    
            var originalTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Got number: {0} - thread {1}", num, 
                                        Thread.CurrentThread.ManagedThreadId);
            });
    
            var contTask = originalTask
                .ContinueWith(task =>
                {
                    Console.WriteLine("Continuation {0} - thread {1}", num, 
                                        Thread.CurrentThread.ManagedThreadId);
                });
    
            tasks.Add(originalTask); // comment and un-comment this line to see change in behavior
            tasks.Add(contTask); // same as adding nextTask in your original prog.
    
        }
    
        Task.WaitAll(tasks.ToArray());
    }
