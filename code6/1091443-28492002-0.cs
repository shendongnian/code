    private ObservableCollection<Mechanism> _mechanisms;
    public ObservableCollection<Mechanism> Mechanisms
    {
        get { return _mechanisms; }
        set
        {
            _mechanisms = value;
            OnPropertyChanged("Mechanisms");
        }    
    }
