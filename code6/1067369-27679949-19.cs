      private int _id=1;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                if (SelectedProduct!=null)
                {
                    SelectedProduct.ID = _id;
                }
                OnPropertyChanged("Id");
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                if (SelectedProduct != null)
                {
                    SelectedProduct.Name = _name;
                }
                OnPropertyChanged("Name");
            }
        }
        private double _price = 0;
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                if (SelectedProduct != null)
                {
                    SelectedProduct.Price = _price;
                }
                OnPropertyChanged("Price");
            }
        }
      
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                Id = _selectedProduct != null ? _selectedProduct.ID : 0;
                Name = _selectedProduct != null ? _selectedProduct.Name : "";
                Price = _selectedProduct != null ? _selectedProduct.Price : 0;
                
                OnPropertyChanged("SelectedProduct");
            }
        }
