    Task task1 = Task.Factory
            .StartNew(() => Console.WriteLine("Basic action"))
            .ContinueWith(t1 => { throw new Exception("Intentional Exception"); });
    Task task2 = task1
            .ContinueWith(t2 => Console.WriteLine("Caught exception"));
    task2.Wait();
    task1 = null; // ensure the object is in fact collected
