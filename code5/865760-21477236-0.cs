	public partial class ObservableEx
	{
		public static IObservable<TValue> StartWith<TValue>(TValue value)
		{
			return Observable.Create<TValue>(o =>
			{
				o.OnNext(value);
				return Disposable.Empty;
			});
		}
	}
