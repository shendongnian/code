    public class CalendarDayView : INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<CalendarEvent> _events;
    
        public ObservableCollection<CalendarEvent> Events 
        { 
            get { return _events; }
            set
            {
                _events = value;
                RaisePropertyChanged("Events");
            }
        }
    
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
