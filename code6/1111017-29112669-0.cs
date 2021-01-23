	public class PayWrapper : IPay
	{
		private readonly IPay _wrapped;
		public PayWrapper(IPay wrapped)
		{
			if (wrapped == null) throw new ArgumentNullException(nameof(wrapped));
			_wrapped = wrapped;
		}
		public void DecreasePay()
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			_wrapped.DecreasePay();
			sw.Stop();
			Console.WriteLine(sw.Elapsed);
		}
		public void IncreasePay()
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			_wrapped.IncreasePay();
			sw.Stop();
			Console.WriteLine(sw.Elapsed);
		}
	}
