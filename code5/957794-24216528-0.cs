    private ObservableCollection<string> _listModelBinding;
    public ObservableCollection<string> ListModelBinding
    {
        get { return _listModelBinding; }
        set { _listModelBinding= value; RaisePropertyChanged("ListModelBinding"); }
    }
    public MainViewModel()
    {
        ListModelBinding = ListModelBinding.OrderBy(x => x.ToString());
    }
