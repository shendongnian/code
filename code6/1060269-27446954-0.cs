    private ProductFamily _selectedProduct;
    public ProductFamily SelectedProduct
    {
        get { return _selectedProduct; }
        set
        {
            this.SetPropertyChanged(ref _selectedProduct, value)
            Limits.Clear(); // or Limits = new ...
            Task.Run(() => LongTask());
        }
    }
    private void LongTask()
    {
        var list = new List<BindedLimit>();
        ...
        App.Current.Dispatcher.Invoke(() => Limits = new ObservableCollection<BindedItems>(list));
    }
