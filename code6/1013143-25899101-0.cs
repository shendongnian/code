    static int count = 10;
    static void Main(string[] args)
    {
       var timer = new System.Timers.Timer();
       timer.Interval = 1000;
       timer.Elapsed += (s, e) =>
       {
          Console.WriteLine(count--);
          if (count < 0) timer.Stop();
       };
       //simulate button press
       while (Console.ReadKey().Key != ConsoleKey.Escape)
       {
          count = 10;
          timer.Start();
       }
    }
