    bw1.DoWork += delegate { 
        Console.WriteLine("Worker 1 started"); 
        Thread.Sleep(10000);
        Console.WriteLine("Worker 1 finished");
    };
    bw2.DoWork += delegate {
        Console.WriteLine("Worker 2 started"); 
        Console.WriteLine("Worker 2 finished"); 
    };
    bw1.RunWorkerAsync();
    bw2.RunWorkerAsync();
