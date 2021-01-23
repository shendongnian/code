	void Main()
	{
		var now = DateTime.Now;
	
		var events = new List<Tuple<DateTime, string>> {
			Tuple.Create(now.AddSeconds(5), "A"),
			Tuple.Create(now.AddSeconds(10), "B"),
			Tuple.Create(now.AddSeconds(15), "C")
		};
		
		var enumerator = events.GetEnumerator();
		
		var eventSource = Observable.Generate(
			(IEnumerator<Tuple<DateTime,string>>)events.GetEnumerator(),
			s => s.MoveNext(),
			s => s,
			s => s.Current.Item2, // the data
			s => s.Current.Item1); // the timing
			
		eventSource.Subscribe(Console.WriteLine);						
	}
