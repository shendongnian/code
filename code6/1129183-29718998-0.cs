    public RaPoint Position
    {
        get
        {
            return _Position;
        }
        set
        {
            _Position = value;
            RaisePropertyChanged(PositionPropertyName);
        }
    }
