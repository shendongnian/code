	ObservableCollection<string> collection = new ObservableCollection<string>();
	
	collection.CollectionChanged += (sender, args) => {
		if(args.Action == NotifyCollectionChangedAction.Add &&
		    collection.Count == 3)
			HandleItemsAdded(args.NewItems.Cast<string>());			
	};
	
	collection.Add("www.1.com");
	collection.Add("www.2.com");
	collection.Add("www.3.com");
