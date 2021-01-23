    private ObservableCollection<Ligne> _ListeLigne = new ObservableCollection<Ligne>();
    public ObservableCollection<Ligne> ListeLigne
    {
        get { return _ListeLigne; }
        set
        {
            _ListeLigne = value;
            OnPropertyChanged("ListeLigne");
        }
    }
