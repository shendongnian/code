    public double FirstSourceValue
    {
        get { return firstSourceValue; }
        set
        {
             firstSourceValue = value;
             NotifyPropertyChanged(); //Notify for this property
             NotifyPropertyChanged("DerivedValue"); //Notify for the other one
        }
    }
