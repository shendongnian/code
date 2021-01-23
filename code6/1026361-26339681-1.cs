	async void Method()
	{
		var TimeConsumingTask = Task.Factory.StartNew(() => 
			{
				return TimeConsumingWebServiceCall();
			});
		var context = GetSomeContext();
		context.Result = await TimeConsumingTask;
	}
