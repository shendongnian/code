    using System;
    using System.Threading;
    using WebBackgrounder;
    
    [assembly: WebActivator.PreApplicationStartMethod(
      typeof(SampleAspNetTimer), "Start")]
    
    public static class SampleAspNetTimer
    {
        private static readonly Timer _timer = new Timer(OnTimerElapsed);
        private static readonly JobHost _jobHost = new JobHost();
    
        public static void Start()
        {
            _timer.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));
        }
    
        private static void OnTimerElapsed(object sender)
        {
            _jobHost.DoWork(() => { /* What is it that you do around here */ });
        }
    }
