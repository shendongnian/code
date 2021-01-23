    private ObservableCollection<Suplemento> _suplementos;
    public ObservableCollection<Suplemento> Suplementos
    {
        get
        {
            return this._suplementos; 
        }
        set
        {
            this._suplementos = value;
            RaisePropertyChanged("Suplementos");
        }
    }
