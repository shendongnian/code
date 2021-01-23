    public object ConsignorViewModel
    {
       get { return consignorViewModel; }
       set
       {
           consignorViewModel = value;
           RaisePropertyChanged("ConsignorViewModel");
           RaisePropertyChanged("EnableConsignor");
       } 
    }
