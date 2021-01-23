    public Task<IList<int>> GetNumbers()
	{
		return Task.Factory.StartNew<IList<int>>(() => 
		{
			var listsSharedWithMe = new ObservableCollection<int>();
			System.Threading.Thread.Sleep(2000);
			for (int i = 0; i < 5; i++)
				listsSharedWithMe.Add(i);
			return listsSharedWithMe;
		});
	}
