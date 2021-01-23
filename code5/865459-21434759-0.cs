    public class SomeViewModel : ViewModelBase
    {
        private int? _duration;
        private decimal? _amount;
        public int? Duration
        {
            get { return _duration; }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    RaisePropertyChanged("Duration");
                    RaisePropertyChanged("Total");
                }
            }
        }
        public decimal? Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    RaisePropertyChanged("Amount");
                    RaisePropertyChanged("Total");
                }
            }
        }
        public decimal? Total
        {
            get
            {
                if (Amount.HasValue && Duration.HasValue)
                    return Amount.Value * Duration.Value;
                return null;
            }
        }
    }
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
