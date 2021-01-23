    static void Main(string[] args)
    {
      // cancellation by keyboard string
      CancellationTokenSource cts = new CancellationTokenSource();
    
      // thread that listens for keyboard input
      var kbTask = Task.Run(() =>
      {
        string userInput = Console.ReadLine();
        if(userInput == "c")
          cts.Cancel();
        else
        {
           // handle input
           Console.ReadLine();
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
