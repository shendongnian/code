    public class ViewModel: INotifyPropertyChanged
    {
        private double _value;
        public double Value //or float, whatever
        {
            get { return _value; }
            set
            {
                _value = value;
                NotifyPropertyChanged("Value");
            }
        }
    
        //... Implement INotifyPropertyChanged here
    }
