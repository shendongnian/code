    private ObservableCollection<Book> _load = new ObservableCollection<Book>();
    public ObservableCollection<Book> Load
    {
    	get { return _load; }
    	set
    	{
    		_load = value;
    		NotifyPropertyChanged("Load");
    		NotifyPropertyChanged("Titles");
    		NotifyPropertyChanged("Authors");
    	}
    }
    
    public ObservableCollection<String> Titles
    {
    	get { return new ObservableCollection<string>(Load.Select(o => o.Title).Distinct()); }
    	//get { return new ObservableCollection<string>(Load.GroupBy(o => o.Title).Select(o => o.Key)); }
    }
    
    public ObservableCollection<String> Authors
    {
    	get { return new ObservableCollection<string>(Load.Select(o => o.Author).Distinct()); }
    	//get { return new ObservableCollection<string>(Load.GroupBy(o => o.Title).Select(o => o.Key)); }
    }
    
    public void LoadData()
    {
    	var orderedGenre = (from Book b in BookDB.Books select b);
    	Load = new ObservableCollection<Book>(orderedGenre);
    }
