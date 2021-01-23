    public MyViewModel()
    {
       PropertyChanged += MyViewModel_PropertyChanged;
    }
    private bool handleSelectedProductChanges = true;
    void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
       if(e.PropertyName == "ProductName")
       {
          handleSelectedProductChanges = false;
          // update ProductRecords
          handleSelectedProductChanges = true;
       }
       else if(e.PropertyName == "SelectedProduct")
       {
          if (handleSelectedProductChanges && SelectedProduct != null)
          {
              ProductName = SelectedProduct.Name;
              ShowProductList = false;
          }
        }
    }
