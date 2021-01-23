    public string Name1
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged("Name1"); 
        }
    }
    private ObservableCollection<string> listString = new ObservableCollection<string>();
    public ObservableCollection<string> ListString
    {
        get { return listString ; }
        set
        {
            listString = value;
            OnPropertyChanged("ListString"); 
        }
    }
