    public class TestData : INotifyPropertyChanged
    {
        public double Test 
        { 
            get { return _test; } 
            set 
            { 
                _test = value;  
                OnPropertyChange("Test");
            }
        }
    
        private double _test;
    
        private void OnPropertyChange(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public event PropertyChanged;
    }
