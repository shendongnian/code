  	private IEnumerable _boundList;
    private ObservableCollection<int> _firstCollection;
    private ObservableCollection<string> _SecondCollection;
    public IEnumerable BoundList
    {
        get { return _boundList; }
        set
        {
            _boundList = value;
            OnPropertyChanged("BoundList");
        }
    }
    public void CommandExecuted()
    {
		BoundList  = _boundList == _firstCollection ? _SecondCollection : _firstCollection;
    }
