    public Task<IList<int>> GetNumbers()
	{
		return Task.Factory.StartNew<IList<int>>(() => 
		{
			var lists = new ObservableCollection<int>();
			System.Threading.Thread.Sleep(2000);
			for (int i = 0; i < 5; i++)
				lists.Add(i);
			return lists;
		});
	}
