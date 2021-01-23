    public string ProductName
      {
        get { return _productName; }
        set
          {
            _productName = value;
            _firstLoad = false;
            SaveProduct.OnCanExecuteChanged();
            OnPropertyChanged("ProductName");
          }
     }
