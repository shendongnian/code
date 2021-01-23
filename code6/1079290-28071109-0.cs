	Parallel.ForEach(Items, item =>
    {
		bool succeeded = false;
		while(!succeeded)
		{
			try
			{
				service.DoSomeAction(item.Item1, item.Item2, item.Item3);
				succeeded = true;
			}
			catch(MyException) //the expected Exception, let others get thrown
			{
			}
		}
	});
