    void async Main()
    {
       await Poetry();
       while (true)
       {
           Console.WriteLine("Outside, within Main.");
          Thread.Sleep(200);
       }
    }
