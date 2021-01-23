    var commands = new ConcurrentQueue<string>();
    var myThread = new Thread(_ =>
      {
          while(true)
          {
             // Do work
             ...
            // check commands
            string command;
            if (commands.TryDequeue(out command))
            { 
                 //handle command
            }
          }
      });
    myThread.Start();
    commands.Enqueue(Console.ReadLine());
