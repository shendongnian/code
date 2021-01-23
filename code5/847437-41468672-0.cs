    ObservableCollection<DataPoint> Data { get; set; } 
        = new ObservableCollection<DataPoint>();
    public PlotModel PlotModel
    {
        get { return _plot_model; }
        set
        {
            _plot_model = value;
            RaisePropertyChanged(() => PlotModel);
        }
    }
    PlotModel _plot_model;
    // Inside constructor:
    Data.CollectionChanged += (a, b) => PlotModel.InvalidatePlot(true);
