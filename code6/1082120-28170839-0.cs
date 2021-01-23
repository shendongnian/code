    public static async Task CheckTask(CancellationToken token)
    {
       do
       {
          // Do some processing
          Console.WriteLine("Processing");
          await Task.Delay(1500);
       } while (!token.IsCancellationRequested);
    
       Console.WriteLine("Bye bye");
    }
