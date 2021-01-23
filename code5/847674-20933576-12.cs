    public class SomeViewModel : INotifyPropertyChanged
    {
        #region Properties (that support INotifyPropertyChanged)
        private IEnumerable<Result> _results;
        public IEnumerable<Result> Results
        {
            get
            {
                return _results;
            }
            set
            {
                if (value != _results)
                {
                    _results = value;
                    OnPropertyChanged("Results");
                }
            }
        }
        #endregion
        // A reference to the service that will get some data
        private IDataService _dataService;
        public SomeViewModel(IDataService dataService)
        {
            _dataService = dataService;
            var period = TimeSpan.FromMinutes(1);
            var timer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
            {
                // do your query/work here
                GetData();
            },
            period);
        }
        #region Data fetch method
        /// <summary>
        /// Method to get some data - waits on a service to return some results
        /// </summary>
        void GetData()
        {
            // Get the data
            _dataService.GetResults((result) => 
            { 
                // Try this instead
                Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.Invoke(() => {
                Results = result.Data; }
            });
        }
        #endregion
        #region INotifyPropertyChanged
        // Note: usually most MVVM frameworks have a base class which implements the INPC interface for you (such as PropertyChangedBase in Caliburn Micro)
        // so it might be worth fishing around in your framework for it if you are using one.. If you aren't using a framework then you are a braver man than me
        // start using one now!
        /// <summary>
        /// The property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// The helper function to raise the event
        /// </summary>
        /// <param name="propertyName">Name of the property that changed (to tell the binding system which control to update on screen based on bindings)</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
