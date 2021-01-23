    private static void Main(string[] args)
    {
        List<ObservableCollection<int>> collections = new List<ObservableCollection<int>>();
        for (int i = 0; i < 10; i++)
        {
            ObservableCollection<int> collection = new ObservableCollection<int>();
            collection.CollectionChanged += (s, e) =>
			{
			    if (e.Action == NotifyCollectionChangedAction.Add)
				{
					// Can reference `collection` directly here
				}
			};
            collections.Add(collection);
        }
        collections[5].Add(1234);
    }
