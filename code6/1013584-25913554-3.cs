    static void Main(string[] args)
    {
       int timeout = 10;
       int timeoutCount = 10;
       while (true) 
       {
          //Here you can check cancellation flag
          if(timeout == timeoutCount)
          {
            timeoutCount = 0;
            // Get a list of processes
            // Check to see if process has exited
            // If so, run *this* code then exit console application.
            // If not, keep timer running.
          }
          Thread.Sleep(1000); // Wait 1s and retry your previous actions
          timeoutCount++;
       }
    }
