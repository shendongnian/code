    using System.Threading;
    using System.Threading.Tasks;
    public sealed class TaskTimer
    {
        Action onTick;
        CancellationTokenSource cts;
        public bool IsRunning { get; private set; }
        public TimeSpan Interval { get; set; }
        public TaskTimer(TimeSpan interval, Action onTick)
        {
            this.Interval = interval;
            this.onTick = onTick;
        }
        public async void Start()
        {
            Stop();
            cts = new CancellationTokenSource();
            this.IsRunning = true;
            while (this.IsRunning)
            {
                await Task.Delay(this.Interval, cts.Token);
                if (cts.IsCancellationRequested)
                {
                    this.IsRunning = false;
                    break;
                }
                if (onTick != null)
                    onTick();
            }
        }
        public void Stop()
        {
            if (cts != null)
                cts.Cancel();
        }
    }
