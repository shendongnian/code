	public class CPUTime : IDisposable
	{
		private PerformanceCounter counter;
		private DateTime lastcheck;
		private float lastvalue;
		public float Value
		{
			get
			{
				if ((DateTime.Now - lastcheck).TotalMilliseconds > 950)
				{
					lastvalue = counter.NextValue();
					lastcheck = DateTime.Now;
				}
				return lastvalue;
			}
		}
		public CPUTime()
		{
			counter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
			counter.NextValue();
			lastcheck = DateTime.Now;
		}
		~CPUTime()
		{
			Dispose();
		}
		public void Dispose()
		{
			if (counter != null)
			{
				counter.Dispose();
				counter = null;
			}
		}
		public override string ToString()
		{
			return string.Format("{0:0.00}%", Value);
		}
	}
