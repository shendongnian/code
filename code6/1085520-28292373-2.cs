    private static void Main(string[] args)
    {
        List<ObservableCollection<int>> collections =
			Enumerable
				.Range(0, 10)
				.Select(n => new ObservableCollection<int>())
				.ToList();
		
		collections
			.ForEach(collection =>
			{
				collection.CollectionChanged += (s, e) =>
				{
					if (e.Action == NotifyCollectionChangedAction.Add)
					{
						// Can reference `collection` directly here
					}
				};
			});
        collections[5].Add(1234);
    }
