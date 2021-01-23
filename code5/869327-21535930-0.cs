    ObservableCollection<Classes.Charges> _taxlist = new ObservableCollection<Classes.Charges>();
    public ObservableCollection<Classes.Charges> TaxList
    {
        get
        {
            return _taxlist;
        }
        set
        {
            _taxlist = value;
            OnPropertyChanged("TaxList");
        }
    }
