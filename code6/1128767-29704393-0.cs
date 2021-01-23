    public double[] Axes
    {
        get
        {
            return _axes;
        }
        set
        {
            _axes = value;
            if (PropertyChanged != null)
            {
                NotifyPropertyChanged("Axes");
            }
        }
    }
