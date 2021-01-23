    // Properties
    public string ProductCode { 
        get { return _productCode; }
        set {
            _productCode = value;       
            base.NotifyPropertyChanged("ProductCode");
            base.NotifyPropertyChanged("Description");
        }
    }
    public string Description {
        get { 
            var matchingProduct = ViewModel.ProductList.FirstOrDefault(product => product.ProductCode == ProductCode);
            return (matchingProduct == null ? "" : matchingProduct.Description);
        }
    }       
