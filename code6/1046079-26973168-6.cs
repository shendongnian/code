    public ObservableCollection<EllipseXY> Ellipses
    {
        get { return ellipses; }
        set
        {
            if (ellipses == null) ellipses = new ObservableCollection<EllipseXY>();
            else
            {
                ellipses = value;
                RaisePropertyChanged("Ellipses");
            }
        }
    }
