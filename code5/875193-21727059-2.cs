	private IObservable<List<string>> GetStrings(SomeDataObject dataObject)
	{
		return Observable.Create<List<string>>(o=>
		{
			SomeDataObject.ReadyEventHandler ReadyHandler = null;
			SomeDataObject.ErrorEventHandler ErrorHandler = null;
	
			ReadyHandler = () =>
			{
				var results = new List<string>(dataObject.ItemCount);
				for (int i =0; i < dataObject.ItemCount; i++)
					results.Add(dataObject[i].ToString());
	
				o.OnNext(results);
				o.OnCompleted();
			};
	
			ErrorHandler = () =>
			{
				o.OnError(new Exception("oops!"));
			};
	
			dataObject.Ready += ReadyHandler;
			dataObject.Error += ErrorHandler;
	
			dataObject.DoRequest();
	
			return Disposable.Create(()=>
				{
					dataObject.Ready -= ReadyHandler;
					dataObject.Error -= ErrorHandler;
				});
		});
	}
