    public double MapRotationAngle
    {
        get { return _mapRotationAngle; }
        set
        {
            _mapRotationAngle= value;
            OnPropertyChanged("MapRotationAngle");
            OnPropertyChanged("FinalRotationAngle");
        }
    }
    public double NorthOrientationAngle
    {
        get { return _northOrientationAngle; }
        set
        {
            _northOrientationAngle= value;
            OnPropertyChanged("NorthOrientationAngle");
            OnPropertyChanged("FinalRotationAngle");
        }
    }
    public double FinalRotationAngle
    {
        get { return NorthOrientationAngle + MapRotationAngle; }
    }
