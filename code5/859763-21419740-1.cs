    static void Main(string[] args)
    {
        Console.WriteLine("Enter Main, thread #" + Thread.CurrentThread.ManagedThreadId);
    
        // delegate to be executed on a pool thread
        Func<int> doWork = () =>
        {
            Console.WriteLine("Enter doWork, thread #" + Thread.CurrentThread.ManagedThreadId);
            // simulate CPU-bound work
            Thread.Sleep(2000);
            Console.WriteLine("Exit doWork");
            return 42;
        };
    
        // delegate to be called when doWork finished
        AsyncCallback onWorkDone = (ar) =>
        {
            Console.WriteLine("enter onWorkDone, thread #" + Thread.CurrentThread.ManagedThreadId);
        };
    
        // execute doWork asynchronously on a pool thread
        IAsyncResult asyncResult = doWork.BeginInvoke(onWorkDone, null); 
    
        // optional: blocking wait for asyncResult.AsyncWaitHandle
        Console.WriteLine("Before AsyncWaitHandle.WaitOne, thread #" + Thread.CurrentThread.ManagedThreadId);
        asyncResult.AsyncWaitHandle.WaitOne();
    
        // get the result of doWork
        var result = doWork.EndInvoke(asyncResult);
        Console.WriteLine("Result: " + result.ToString());
    
        // onWorkDone AsyncCallback will be called here on a pool thread, asynchronously 
        Console.WriteLine("Press Enter to exit");
        Console.ReadLine();
    }
