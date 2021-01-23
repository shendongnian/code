    static void Main()
    {
        Thread t = new Thread (ThreadTest.WriteY);          // Kick off a new thread
        t.Start();                                          // running WriteY()
    
        // Simultaneously, do something on the main thread.
        for (int i = 0; i < 1000; i++) 
        {
             Console.Write ("x");
             Thread.Sleep(1);
        }
    }
   
    
    class ThreadTest
    {
        for (int i = 0; i < 1000; i++) 
        {
             Console.Write ("y");
             Thread.Sleep(1);
        }
    }
