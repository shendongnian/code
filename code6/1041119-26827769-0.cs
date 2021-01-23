	private IObservable<string> GetCompleteMessage(IObservable<byte[]> bytes)
	{
		return Observable.Create<string>(o =>
		{
			var subject = new Subject<string>();
			return new CompositeDisposable(
				subject.Subscribe(o),
				bytes
					.Aggregate(
						"",
						(s, bs) =>
						{
							var parts = (s + Encoding.ASCII.GetString(bs))
								.Split(new [] { (char)10 });
							foreach (var part in parts.Take(parts.Length - 1))
							{
								subject.OnNext(part);
							}
							return parts.Last();
						})
					.Subscribe(subject));
		});
	}
