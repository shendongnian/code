	public IObservable<string> GetDocumentObservable(int numParagraphs, int latency)
	{
		return
			Observable
				.Generate(
					0,
					i => i < numParagraphs,
					i => i + 1,
					i => "Some String",
					i => i == 0
						? TimeSpan.Zero
						: TimeSpan.FromSeconds(1.0))
				.Do(x => Console.WriteLine(
					"Service On thread {0}",
					Thread.CurrentThread.ManagedThreadId));
	}
