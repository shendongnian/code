	void Main()
	{
		var queue = new ConcurrentQueue<int>();
		queue.Enqueue(1);
		queue.Enqueue(2);
		queue.Enqueue(3);
		queue.Enqueue(4);
		queue.ObserveEach(TimeSpan.FromSeconds(1)).DumpLive("queue");
	}
	
	// Define other methods and classes here
	public static class Ex {
		public static IObservable<T> ObserveConcurrentQueue<T>(this ConcurrentQueue<T> queue, TimeSpan period) 
		{
			return Observable
				.Generate(
					queue, 
					x => true,
					x => x, 
					x => x.DequeueOrDefault(), 
					x => period)
				.Where(x => !x.Equals(default(T)));
		}
		
		public static T DequeueOrDefault<T>(this ConcurrentQueue<T> queue)
		{
			T result;
			if (queue.TryDequeue(out result))
				return result;
			else
				return default(T);
		}
	}
