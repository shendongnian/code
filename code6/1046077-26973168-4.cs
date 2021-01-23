    private ObservableCollection<EllipseXY> ellipses;
    public ObservableCollection<EllipseXY> Ellipses
    {
        get { return ellipses; }
        set
        {
            if (ellipses == null)
            {
                ellipses = new ObservableCollection<EllipseXY>();
                ellipses = value;
            }
            else
            {
                ellipses = value;
                RaisePropertyChanged("Ellipses");
            }
        }
    }
