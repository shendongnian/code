    class Program
    {
      static void Main(string[] args)
      {
        // cancellation by keyboard string
        CancellationTokenSource cts = new CancellationTokenSource();
    
        // thread that listens for keyboard input
        var kbTask = Task.Run(() =>
        {
          while(true)
          {
            string userInput = Console.ReadLine();
            if(userInput == "c")
            {
              cts.Cancel();
              break;
            }
            else
            {
              // handle input
              Console.WriteLine("Executing user command {0}...", userInput);
            }
          }
        });
    
        // thread that performs main work
        Task.Run(() => DoWork(), cts.Token);
    
        Console.WriteLine("Type commands followed by 'ENTER'");
        Console.WriteLine("Enter 'C' to end program.");
        Console.WriteLine();
    
        // keep Console running until cancellation token is invoked
        kbTask.Wait();
      }
    
      static void DoWork()
      {
        while(true)
        {
          Thread.Sleep(3000);
          Console.WriteLine("Doing work...");
        }
      }
    }
