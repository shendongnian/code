    public IObservable<T> GetEvent<T>()
    {		
		return Observable.Create<T>(o =>
		{
			var source = _subject.OfType<T>();
			var m = new SingleAssignmentDisposable();
			m.Disposable = source.Subscribe(
				x => {
					try {
						o.OnNext(x);						
					}
					catch(Exception e) {
						Console.WriteLine(e);
						m.Dispose();
					}
				},
				e => {
					try {
						o.OnError(e);						
					}
					catch(Exception ex) {
						Console.WriteLine(ex);
					}
					finally {
						m.Dispose();
					}
				},
				() => {
					try {
						o.OnCompleted();						
					}
					catch(Exception e) {
						Console.WriteLine(e);
					}
					finally {
						m.Dispose();
					}
				}				
			);
		
			return m;
		});
	}
