    public int ThicknessUnit
    {
        get { return(int) _thicknessUnit;  }
        set
        {
            _thicknessUnit = (eThicknessUnits)value;
            NotifyPropertyChanged();
        }
    }
