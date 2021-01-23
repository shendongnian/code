    public class PaymentDetailInfo : INotifyPropertyChanged
    {
    /// <summary> The payment model.
    /// </summary>
    private Payment _model = null;
    /// <summary> Constructor.
    /// </summary>
    public PaymentDetailInfo(Payment payment)
    {
        _model = payment;
    }
    /// <summary> Wrapper around Payment.ConsideredValidNormalOverTime.
    /// </summary>
    public int ConsideredValidNormalOverTime
    {
        get { return _model.ConsideredValidNormalOverTime; }
        set
        {
            _model.ConsideredValidNormalOverTime = value;
            // make sure to set the property and not the backing field, otherwise OnPropertyChanged won't be 
            // called and the value of _sumOfValidNormalOverTimePrice will be incorrect
            SumOfValidNormalOverTimePrice = value;
            OnPropertyChanged(new PropertyChangedEventArgs("ConsideredValidNormalOverTime"));
        }
    }
    private int _sumOfValidNormalOverTimePrice = 0;
    public int SumOfValidNormalOverTimePrice
    {
        get { return _sumOfValidNormalOverTimePrice; }
        private set
        {
            _sumOfValidNormalOverTimePrice = 100 * value / 60;
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
