    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private readonly Model _model = new Model();
        private int _data;
        public int Data
        {
            get { return _data; }
            set
            {
                // NotifyPropertyChanged boilerplate
                if (_data != value)
                {
                    _data = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Data"));
                }
            }
        }
        /// <summary>
        /// Some sort of trigger that starts querying the model; for simplicity, we assume this to come from the UI thread.
        /// If that's not the case, save the UI scheduler in the constructor, or pass it in through the constructor.
        /// </summary>
        internal void UpdateData()
        {
            _model.GetDataAsync().ContinueWith(t => Data = t.Result, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
