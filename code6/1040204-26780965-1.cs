    public string MyRegimeAlias
    {
        get { return _NewRegime.regimeAlias; }
        set
        {
            _NewRegime.regimeAlias = value;
            OnPropertyChanged("MyRegimeAlias");
        }
    }
