    private ObservableCollection<TClass> _SomeObservableCollection;
    
    public ObservableCollection<TClass> SomeObservableCollection
    {
    	get { return _SomeObservableCollection ?? (_SomeObservableCollection = SomeObservableCollectionItems()); }
    }
    
    private ObservableCollection<TClass> SomeObservableCollectionItems()
    {
    	var resultCollection = new ObservableCollection<TClass>();
    
    	foreach (var item in SomeModelCollection)
    	{
    		var newPoint = new TClass(item) {IsLocated = true};
    		newPoint.PropertyChanged += OnItemPropertyChanged;
    		resultCollection.Add(newPoint);
    	}
    
    	resultCollection.CollectionChanged += OnSomeObservableCollectionCollectionChanged;
    
    	return resultCollection;
    }
    
    private void OnSomeObservableCollectionCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
    	if (e.NewItems != null)
    	{
    		foreach (TClass TClass in e.NewItems)
    		{
    			TClass.PropertyChanged += OnItemPropertyChanged;
    		}
    	}
    	if (e.OldItems != null)
    	{
    		foreach (TClass TClass in e.OldItems)
    		{
    			TClass.PropertyChanged -= OnItemPropertyChanged;
    		}
    	}
    	if (!Patient.HasChanges)
    		Patient.HasChanges = true;
    }
    
    
    private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    	if (e.PropertyName != "ItemArchivedProperty") return;
    	// set Archived = true or set Archived = false 
    }
