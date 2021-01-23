    public class CustomStopwatch : Stopwatch
        {
    
            public DateTime? StartAt { get; private set; }
            public DateTime? EndAt { get; private set; }
    
    
            public void Start()
            {
                StartAt = DateTime.Now;
    
                base.Start();
            }
    
            public void Stop()
            {
                EndAt = DateTime.Now;
    
                base.Stop();
            }
    
            public void Reset()
            {
                StartAt = null;
                EndAt = null;
    
                base.Reset();
            }
    
            public void Restart()
            {
                StartAt = DateTime.Now;
                EndAt = null;
    
                base.Restart();
            }
    
        }
