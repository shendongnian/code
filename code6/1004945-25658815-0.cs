    public class ViewModel : INotifyPropertyChanged
    {
        private double _value1;
        private double _value2;
        private double _result;
        
        public double Value1
        {
            get { return _value1; }
            set
            {
                _value1 = value;
                OnPropertyChanged();
                OnPropertyChanged("Result");
            }
        }
        public double Value2
        {
            get { return _value2; }
            set
            {
                _value2 = value;
                OnPropertyChanged();
                OnPropertyChanged("Result");
            }
        }
        public double Result
        {
            get { return Value1*Value2; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
