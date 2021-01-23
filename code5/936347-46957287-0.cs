    public ViewModel()
    {
         Plot = new PlotModel(); //(Plot is a property using 
                                 // INotifyPropertyChanged)
         PlotGraph = new RelayCommand(OnPlotGraph);
    }
    public RelayCommand PlotGraph {get; set;}
    private async void OnPlotGraph()
    {
         await Task.Run(() => Update());
    }
    private void Update()
    {
        var tempPlot = new PlotModel();
        //(set up tempPlot, add data to tempPlot)
        Plot = tempPlot;
    }
