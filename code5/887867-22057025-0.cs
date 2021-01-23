	private IObservable<double> GeneratePoints()
	{
		return Observable.Generate<int, double>(
			0,
			i => true,
			i => i + 1,
			i => random.Next(0, 100) * (1 / (double)random.Next(1, Math.Min(50, Math.Max(i, 1)))));
	}
