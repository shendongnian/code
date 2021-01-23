	public static class FooEx
	{
		public static IObservable<EventPattern<EventArgs>> Clicks(this Foo source)
		{
			return
				Observable
					.FromEventPattern<EventArgs>(
						h => source.Click += h,
						h => source.Click -= h);
		}
	}
