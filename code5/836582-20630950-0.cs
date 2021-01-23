    private ObservableCollection<myTable> _myCollection;
    /// <summary>
    /// Gets or sets the myTable collection.
    /// </summary>
    public ObservableCollection<myTable> MyCollection
    {
    	get { return _myCollection; }
    	set
    	{
    		if (value == _myCollection) return;
    		_myCollection= value;
    		RaisePropertyChanged(() => MyCollection);
    	}
    }
