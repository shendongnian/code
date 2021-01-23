    public class Payment
    {
        public PaymentDetailInfo DetailInfo = new PaymentDetailInfo();
    
        private int _consideredValidNormalOverTime = 0;
        public int ConsideredValidNormalOverTime
        {
            get
            {
                _return _consideredValidNormalOverTime;
            }
            set
            {
                _consideredValidNormalOverTime = value;
                DetailInfo.SumOfValidNormalOverTimePrice = _consideredValidNormalOverTime;
            }
        }
    }
    
    public class PaymentDetailInfo : INotifyPropertyChanged
    {    
        private int _sumOfValidNormalOverTimePrice = 0;
        public int SumOfValidNormalOverTimePrice
        {
            get
            {
                return __sumOfValidNormalOverTimePrice;            
            }
            set
            {
                __sumOfValidNormalOverTimePrice = 100 * value / 60;
                OnPropertyChanged(new PropertyChangedEventArgs("SumOfValidNormalOverTimePrice"));
            }
        }    
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
