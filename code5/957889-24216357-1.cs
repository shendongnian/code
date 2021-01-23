    private ObservableCollection<ListModel> _listModelBinding;
    public ObservableCollection<ListModel> ListModelBinding
        {
            get { return _listModelBinding; }
            set { _listModelBinding= value; RaisePropertyChanged("ListModelBinding"); }
        }    
