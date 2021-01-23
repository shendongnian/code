    private short operatingMode;
    public short OperatingMode
    {
        get
        {
            return operatingMode;
        }
        set
        {
            if (operatingMode != value)
            {
                operatingMode = value;
                this.RaisePropertyChanged("OperatingMode");
            }
        }
    }
