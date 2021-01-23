    Action action = () =>
    {
        for(int i = 0; i <100; i++)
        {
            Console.WriteLine(String.Format("Step {0} of long running operation", i));
            Thread.Sleep(1000);
        }
    };
    			
    var r = action.BeginInvoke(null, null);
    while(!r.IsCompleted)
    {
        Console.WriteLine("Waiting...");
        Thread.Sleep(100);
    }
