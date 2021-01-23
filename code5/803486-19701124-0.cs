    public static bool Stop = false;
    public static void CheckEvery3Sec()
    {
       System.Timers.Timer tm = new System.Timers.Timer(3000);
       tm.Start();
       tm.Elapsed += delegate
       {
           if (Stop)
           {
              tm.Stop();
              return;
           }
           ...
       };
    }
