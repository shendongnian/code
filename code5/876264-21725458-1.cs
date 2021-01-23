     public MyViewModel()
     {
        PropertyChanged += MyViewModel_PropertyChanged;
     }
     void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
     {
        if(e.PropertyName == "ProductName")
        {
           // update ProductRecords
        }
        else if(e.PropertyName == "SelectedProduct")
        {
           if (SelectedProduct != null)
           {
               ProductName = SelectedProduct.Name;
               ShowProductList = false;
           }
        }
     }
