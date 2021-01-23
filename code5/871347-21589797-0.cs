        public ObservableCollection<PaymentInfo> SelectedPayments
    {
        get { return value; }
        set
        {
            number = value;
            RaisePropertyChanged("SelectedPayments");
        }
    }
