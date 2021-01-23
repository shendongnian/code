	public IObservable<UdpReceiveResult> StreamObserver
	(int localPort, TimeSpan? timeout = null)
	{
	
	
		return Linq.Observable.Create<UdpReceiveResult>(observer =>
		{
			UdpClient client = new UdpClient(localPort);
	
			var o = Linq.Observable.Defer(() => client.ReceiveAsync().ToObservable());
			IDisposable subscription = null;
			if ((timeout != null)) {
				subscription = Linq.Observable.Timeout(o.Repeat(), timeout.Value).Subscribe(observer);
			} else {
				subscription = o.Repeat().Subscribe(observer);
			}
	
			return Disposable.Create(() =>
			{
				client.Close();
				subscription.Dispose();
				// Seems to take some time to close a socket so
				// when we resubscribe there is an error. I
				// really do NOT like this hack. TODO see if
				// this can be improved
				Thread.Sleep(TimeSpan.FromMilliseconds(200));
			});
		});
	}
