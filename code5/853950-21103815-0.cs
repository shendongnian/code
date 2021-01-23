    while( some condition )
    {
        // Check if user pressed a key
        while (Console.KeyAvailable)
        {
            // TODO: Read key
        }
        
        // Do some other processing maybe?
       
        // Sleep for 100 ms as to avoid spinning at 100% cpu
        System.Threading.Thread.Sleep(100);
    }
