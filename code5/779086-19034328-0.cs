    public class ValueChangedPublisher : INotifyPropertyChanged
    {
        private int _prop1;
        private string _prop2;
    
        public event PropertyChangedEventHandler ValueChangedHandler;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public int Prop1
        {
            get { return _prop1; }
            set
            {
                if (_prop1 != value)
                {
                    _prop1 = value;
                    NotifyPropertyChanged();
                }
            }
        }
    
        public string Prop2
        {
            get { return _prop2; }
            set
            {
                if (_prop2 != value)
                {
                    _prop2 = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
