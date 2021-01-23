	void Main()
	{
		var runners = GetRunners();		
		
		Observable.Merge(runners.Select(r => Observable.StartAsync(ct => r.Run(ct, null))
						.Timeout(TimeSpan.FromSeconds(10), Observable.Return(true))))
						.Where(res => !res)
						.Any().Select(res => !res)
						.Subscribe(
							res => Console.WriteLine("Result: " + res));
	}
	
	public static IEnumerable<IRunner> GetRunners()
	{
		yield return new Runner(false);
		yield return new SlowRunner(true);
	}
	
	public interface IRunner
	{
		Task<bool> Run(CancellationToken ct, object o);
	}
	
	public class Runner : IRunner
	{
		protected bool _outcome;
	
		public Runner(bool outcome)
		{
			_outcome = outcome;
		}
	
		public async virtual Task<bool> Run(CancellationToken ct, object o)
		{
			var result = await Task<bool>.Factory.StartNew(() => _outcome);
			return result;
		}
	}
	
	public class SlowRunner : Runner
	{
		public SlowRunner(bool outcome) : base(outcome)
		{
		}
	
		public async override Task<bool> Run(CancellationToken ct, object o)
		{
			var result = await Task<bool>.Factory.StartNew(() => 
			{
				for(int i=0; i<5; i++)
				{
					if(ct.IsCancellationRequested)
					{
						Console.WriteLine("Cancelled");						
					}
					ct.ThrowIfCancellationRequested();
					Thread.Sleep(1000);
				};
				return _outcome;
			});
			return result;
		}
	}
