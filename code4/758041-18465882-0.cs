    public class TrackerViewModel : ViewModelBase, INotifyPropertyChanged
    {
        readonly Tracker _tracker;
        public TrackerViewModel( Tracker tracker )
        {
            _tracker = tracker;
        }
        public bool LastTransmitted
        {
            get
            {
                return _tracker.lastTransmitted;
            }
            set
            {
                _tracker.lastTransmitted = value;
                OnPropertyChanged( "LastTransmitted" );
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged( string name )
        {
            var handler = PropertyChanged;
            if( handler != null ) handler( this, new PropertyChangedEventArgs( name ) );
        }
    }
