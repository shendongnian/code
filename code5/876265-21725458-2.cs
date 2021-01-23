    private bool showProductList;
    public bool ShowProductList
    {
       get { return showProductList; }
       set 
       { 
           showProductList = value;
           RaisePropertyChanged("ShowProductList");
       }
    }
