    public class PlotViewModel : ViewModel, INotifyPropertyChanged
    {
        private int plotId;
        public void NavigatedTo(object parameter) where T : IView
        {
            if(!parameter is int)
                return; // Wrong parameter type passed
            this.plotId = (int)parameter;
            Task.Start( () => {
                // load the data
                PlotData = LoadPlot(plotId);
            });
        }
        private Plot plotData;
        public Plot PlotData {
            get { return plotData; }
            set 
            {
                if(plotData != value) 
                {
                    plotData = value;
                    OnPropertyChanged("PlotData");
                }
            }
        }
    }
