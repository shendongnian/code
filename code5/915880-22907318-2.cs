        private ObservableCollection<Product> _ProductsCollection = new ObservableCollection<Product>();
        public ObservableCollection<Product> ProductsCollection
        {
            get{return _ProductsCollection;}
            set
            {
                _ProductsCollection = value;
                OnPropertyChanged("ProductsCollection");
            }
        }
        private ObservableCollection<Item> _ProductItemsCollection;
        public ObservableCollection<Item> ProductItemsCollection
        {
            get {return _ProductItemsCollection; }
            set
            {
                _ProductItemsCollection = value;
                OnPropertyChanged("ProductItemsCollection");
            }
        }
        private Product _SelectedProduct = null;
        public Product SelectedProduct
        {
            get {return _SelectedProduct;}
            set
            {
                _SelectedProduct = value;
                ProductItemsCollection = _SelectedProduct.ItemsCollection;
                OnPropertyChanged("SelectedProduct");
            }
        }
