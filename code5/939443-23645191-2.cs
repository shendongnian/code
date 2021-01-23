    public string LotNumber
    {
        get { return lotNumber; }
        set
        {
            lotNumber = value;
            RaisePropertyChanged("LotNumber");
        }
    }
