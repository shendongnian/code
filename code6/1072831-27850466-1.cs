    private ObservableCollection<Antecedent> _antecedents;
    public ObservableCollection<Antecedent> Antecedents
    {
        get
        {
            if (_antecedents == null)
                _antecedents = new ObservableCollection<Antecedent>();
            return _antecedents;
        }
    }
