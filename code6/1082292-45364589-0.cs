	var task2 = Task.Run(async () => {
		while (true)
		{
			try
			{
				await MyMethod2();
			} catch
			{
				//super easy error handling
			}
			await Task.Delay(TimeSpan.FromSeconds(5));
		}
	});
    ...
    public async Task MyMethod2()
    {
        //async work here
    }
