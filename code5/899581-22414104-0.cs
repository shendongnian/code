    private static void Main(string[] args)
    {
        new Thread(new ThreadStart(SomeThreadFunction)).Start();
        while(true)
        {
            Console.Read();
        }
    }
    
    static void SomeThreadFunction()
    {
      while(true) {
        Console.WriteLine("Tick");
        Thread.Sleep(1000);
      }
    }
