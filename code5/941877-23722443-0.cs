    enum WaitTime { Off = 0, _5m = 5, _15m = 15, _30m = 30, _1h = 60, _2h = 120, _3h = 180, _6h = 360, _12h = 720, _1d = 1440, _2d = 2880 }
    
    class Program
    {
        static void Main()
        {
            WaitTime wt = WaitTime._15m;
            Console.WriteLine((int)wt);
        }
    }
