     public class MainViewModel : ViewModelBase
    {
        public RelayCommand SetToNow { get; private set; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.SetToNow = new RelayCommand(SetToNowAction);
        }
        private TimeSpan _eventDuration;
        public TimeSpan EventDuration
        {
          get { return _eventDuration; }
          set 
            {
              _eventDuration = value;
              RaisePropertyChanged("EventDuration");
            }
        }
        private void SetToNowAction()
        {
            this.EventDuration = TimeSpan.FromSeconds(0);
        }
 
