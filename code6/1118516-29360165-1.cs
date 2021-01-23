    Task task1 = Task.Factory
            .StartNew(() => Console.WriteLine("Basic action"))
            .ContinueWith(t1 => { throw new Exception("Intentional Exception"); });
    Task task2 = task1
            .ContinueWith(t2 => Console.WriteLine("Caught '" +
                t2.Exception.InnerException.Message + "'"));
    task2.Wait();
    task1.Wait(); // exception thrown here
