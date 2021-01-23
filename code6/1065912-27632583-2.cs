    public RelayCommand Tapped
    {
       get;
       private set;
    }
    public ClassIWroteinViewModel()
    {
        Tapped=new RelayCommand(spnl_tapped);//delegate to spnl_tapped viewmodel method
    }
   
