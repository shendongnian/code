    using System.Windows.Forms;
    public class JobTimer
    {
        public Timer Timer {get; set;}
        public string ID {get; set;}
    }
    public List<JobTimer> _timers = new List<JobTimer>();
    public static void CreateTimer(int id) 
    {
        var timer = new Timer() { Interval = 30000 };
        var job = new JobTimer() { Timer = timer, ID = id };
        _timers.Add(job);
        timer.Tick += JobTimer_Tick;
        timer.Start(); 
    }
    public static void DisposeTimers()
    {
        foreach(var timer in _timers)
            timer.Dispose();
    }
