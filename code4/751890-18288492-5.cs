    private static System.Threading.Timer timer;
    private static void UpdateTitle(object state)
    {
      	TimeSpan running = DateTime.Now - System.Diagnostics.Process.GetCurrentProcess().StartTime;
       	string msg = string.Format("{0} Hours, {1} minutes, {2} seconds", running.Hours, running.Minutes, running.Seconds);
       	Console.Title = msg;
    }
    
    TimeSpan updatePeriod = TimeSpan.FromSeconds(5);
    timer = new System.Threading.Timer(UpdateTitle, null, TimeSpan.Zero, updatePeriod);
    
