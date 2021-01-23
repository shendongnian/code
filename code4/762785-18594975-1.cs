	private void AnyMethod()
	{
		....
		using (var myClientProxy = new MyClientProxy())
		{
			try
			{
				myClientProxy.DoSomething();
			}
			catch (Exception ex)
			{
				ShowException(ex) ;
			}
		}
		....
	}
