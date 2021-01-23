        public class MyViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private ObservableCollection<LocateElement> _history;
    
            public ObservableCollection<LocateElement> history 
            {
                get { return _history; }
                set
                {
                    if (_history != value)
                    {
                        _history = value;
    
                        RaisePropertyChanged("history");
                    }
                }
            }
    
            public MyViewModel()
            {
                _history = new ObservableCollection<LocateElement>();
            }
    
            private void RaisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
