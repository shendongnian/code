    private int _globalPopulation;
    public int GlobalPopulation 
    { 
        get { return _globalPopulation; }
        set
        {
            _globalPopulation = value;
            NotifyPropertyChange("GlobalPopulation");
        }
    }
