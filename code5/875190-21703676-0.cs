    private IObservable<string> GetStrings()
    {
        return Observable.Create<string>(o=>
        {
			SomeDataObject.ReadyEventHandler ReadyHandler = null;
			SomeDataObject.ErrorEventHandler ErrorHandler = null;
		
			ReadyHandler += () =>
			{
				for (int i =0; i < dataObject.ItemCount; i++)
					o.OnNext(dataObject[i].ToString());
		
				o.OnCompleted();
			}
		
			ErrorHandler += () =>
			{
				o.OnError(new Exception("oops!"));
			}
		
			dataObject.Ready += ReadyHandler;
			dataObject.Error += ErrorHandler;
		
			dataObject.DoRequest();
		
			return Disposable.Create(()=>
				{
					dataObject.Ready -= ReadyHandler;
					dataObject.Error -= ErrorHandler;
				});
		}
    }
