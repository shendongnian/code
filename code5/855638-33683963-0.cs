    public class Timer
	{
		private bool timerRunning;
		private TimeSpan interval;
		private Action tick;
		private bool runOnce;
		public Timer(TimeSpan interval, Action tick, bool runOnce = false)
		{
			this.interval = interval;
			this.tick = tick;
			this.runOnce = runOnce;
		}
			
		public Timer Start()
		{
			if (!timerRunning)
			{
				timerRunning = true;
				RunTimer();
			}
			return this;
		}
		public void Stop()
		{
			timerRunning = false;
		}
		private async Task RunTimer()
		{
			while (timerRunning)
			{
				await Task.Delay(interval);
				if (timerRunning)
				{
					tick();
					if (runOnce)
					{
						Stop();
					}
				}
			}
		}
	}
