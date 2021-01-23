    public class PaymentProcessor : INotifyPropertyChanged
    {
        public PaymentProcessor()
        {
        }
        private string _validationStringToPass; 
        public string ValidationStringToPass 
        {
            get { return _validationStringToPass; }
            set
            {
                _validationStringToPass = value;
                OnPropertyChanged("ValidationStringToPass");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        //Get your payments here, might want to put this in the constructor
    	public void GetPayments()
        {
            Binding bind = new Binding() { Source = this, Path = new PropertyPath("ValidationStringToPass") };
            Payment pay = new Payment();
    		BindingOperations.SetBinding(pay, Payment.ValidationStringProperty, bind);
            Payment pay1 = new Payment();
    		BindingOperations.SetBinding(pay1, Payment.ValidationStringProperty, bind);
        }
    }
