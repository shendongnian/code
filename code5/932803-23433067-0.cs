	class MainClass
	{
		//Just to reduce amont of log itmes
		static HashSet<Tuple<string, int>> cache = new HashSet<Tuple<string, int>>();
		public static void LogThread(string msg, bool clear=false) {
			if (clear)
				cache.Clear ();
			var val = Tuple.Create(msg, Thread.CurrentThread.ManagedThreadId);
			if (cache.Add (val))
				Console.WriteLine ("{0}\t:{1}", val.Item1, val.Item2);
		}
		public static async Task<int> FindSeriesSum(int i1)
		{
			LogThread ("Task enter");
			int sum = 0;
			for (int i = 0; i < i1; i++)
			{
				sum += i;
				if (i % 1000 == 0) {
					LogThread ("Before yield");
					await Task.Yield ();
					LogThread ("After yield");
				}
			}
			LogThread ("Task done");
			return sum;
		}
		public static void Main (string[] args)
		{
			LogThread ("Before task");
			var task = FindSeriesSum(1000000);
			LogThread ("While task", true);
			Console.WriteLine ("Sum = {0}", task.Result);
			LogThread ("After task");
		}
	}
