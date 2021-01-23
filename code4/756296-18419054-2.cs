    static void Main(string[] args)
    {
        Observable.Timer(DateTimeOffset.Now, TimeSpan.FromSeconds(0.5))
                  .Subscribe(x => Console.WriteLine("Got " + x));
    
        while (Console.ReadKey().Key != ConsoleKey.Q)
        {
        }
    }
