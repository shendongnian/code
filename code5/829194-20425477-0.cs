	void Main()
	{
		Task.Run(() => {
		var progressor = new Progressor();
		var complete = Observable
			.FromEventPattern(
			h => progressor.Complete += h,
			h => progressor.Complete -= h)
			.Select(_ => "Complete")
			.Take(1);
			// append this to see blocking
			//.DumpLive();
			
			complete.Subscribe(Console.WriteLine);
			
			
		var percentComplete = Observable
			.FromEventPattern<PercentCompleteEventArgs>(
			h => progressor.PercentComplete += h,
			h => progressor.PercentComplete -= h)
			.TakeUntil(complete)
			.Select(i => "PercentComplete " + i.EventArgs.PercentComplete);
			// append this to see blocking
			// .DumpLive();
			
			percentComplete.Subscribe(Console.WriteLine);
		});
		
		Thread.Sleep(5000);
	}
	
	public class Progressor
	{
		public Progressor()
		{
			Observable.Interval(TimeSpan.FromSeconds(1)).Take(10)
				.Subscribe(
				i => RaisePercentComplete(((int)i+1) * 10),
				() => RaiseComplete());
		}
		
		private void RaiseComplete()
		{
			var temp = Complete;
			if(temp != null)
			{
				temp(this, EventArgs.Empty);
			}
		}
		
		private void RaisePercentComplete(int percent)
		{
			var temp = PercentComplete;
			if(temp != null)
			{
				temp(this, new PercentCompleteEventArgs(percent));
			}
		}
		
		public event EventHandler Complete;
		public event EventHandler<PercentCompleteEventArgs> PercentComplete;
	}
	
	public class PercentCompleteEventArgs : EventArgs
	{
		public int PercentComplete { get; private set; }
	
		public PercentCompleteEventArgs(int percent)
		{
			PercentComplete = percent;
		}
	}
