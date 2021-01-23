    public decimal ProductCount
    {
        get 
        {
            //get count from database
            return _productCount;
        }
        set
        {
            _productCount = value;
            //update count in database
            Dispatcher.BeginInvoke(new Action(() => 
            {
                NotifyPropertyChanged("ProductCount");
                NotifyPropertyChanged("DiscountPrice");
                NotifyPropertyChanged("ProductPrice");
                NotifyPropertyChanged("DiscountValue");
                NotifyPropertyChanged("TotalValue");
                NotifyPropertyChanged("ReceiptSum);
                NotifyPropertyChanged("SentToKichen");
            }
        }
    }
