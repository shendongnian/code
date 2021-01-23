    private ObservableCollection<EllipseXY> ellipses = new ObservableCollection<EllipseXY>();
    public ObservableCollection<EllipseXY> Ellipses
    {
        get { return ellipses; }
        set
        {
            if (ellipses == value) return; 
            ellipses = value;
            RaisePropertyChanged("Ellipses");
        }
    }
