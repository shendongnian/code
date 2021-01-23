	public IObservable<string> CallServiceNonBlocking(string url)
	{
		return Observable.Start(() =>
		{
			var httpRequest = (HttpWebRequest)WebRequest.Create(url);
			HttpResponse res = httpRequest.FetchBlocking();
			return res.GetValue(); 
		});
	}
