    private ObservableCollection<Antecedent> _antecedents;
    public ObservableCollection<Antecedent> Antecedents
    {
        get
        {
            return _antecedents;
        }
        set
        {
            if (_antecedents != value)
            {
                _antecedents = value;
                OnPropertyChanged("Antecedents");
            }
        }
    }
