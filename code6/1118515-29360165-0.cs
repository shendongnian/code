    TaskScheduler.UnobservedTaskException += (sender, e) =>
    {
        Console.WriteLine();
        Console.WriteLine("Unobserved exception: " + e.Exception);
        Console.WriteLine();
    };
    //Intentional Exception
    try
    {
        Console.WriteLine("Test 1:");
        Task.Factory
                .StartNew(() => Console.WriteLine("Basic action"))
                .ContinueWith((t1) => { throw new Exception("Intentional Exception"); })
                .ContinueWith(t2 => Console.WriteLine("Caught '" +
                    t2.Exception.InnerException.Message + "'"))
                .Wait();
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception: " + e);
    }
    Console.WriteLine();
    //Unintentional Exception
    try
    {
        Console.WriteLine("Test 2:");
        Task.Factory
                .StartNew(() => Console.WriteLine("Basic action"))
                .ContinueWith(
                    t3 => { throw new Exception("Unintentional Exception (bug)"); })
                .Wait();
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception: " + e);
    }
    Console.WriteLine();
    Console.WriteLine("Done running tasks");
    GC.Collect();
    GC.WaitForPendingFinalizers();
    Console.WriteLine("Done with GC.Collect() and finalizers");
    Console.ReadLine();
