        class ProductsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Product> Products { get; set; }
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set 
            { 
                _selectedProduct = value; 
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedProduct"));
            }
        }
        public ProductsViewModel()
        {
            Products = new ObservableCollection<Product>();
            Products.Add(new Product() { Name = "ProductA" });
            Products.Add(new Product() { Name = "ProductB" });
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
