    public class PclTimer
	{
	    public bool IsRunning { get; private set; }
	    public TimeSpan Interval { get; set; }
	    public Action Tick { get; set; }
	    public bool RunOnce { get; set; }
	    public Action Stopped { get; set; }
	    public Action Started { get; set; }
		public PclTimer(TimeSpan interval, Action tick = null, bool runOnce = false)
		{
			Interval = interval;
			Tick = tick;
			RunOnce = runOnce;
		}
			
		public PclTimer Start()
		{
			if (!IsRunning)
			{
				IsRunning = true;
			    Started?.Invoke();
				var t = RunTimer();
			}
			return this;
		}
		public void Stop()
		{
			IsRunning = false;
		    Stopped?.Invoke();
		}
		private async Task RunTimer()
		{
			while (IsRunning)
			{
				await Task.Delay(Interval);
				if (IsRunning)
				{
					Tick?.Invoke();
					if (RunOnce)
					{
						Stop();
					}
				}
			}
		}
	}
