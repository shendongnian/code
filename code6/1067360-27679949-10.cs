    public class ProductViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> m_Products;
        public ProductViewModel()
        {
            m_Products = new ObservableCollection<Product>
            {
                new Product {ID = 1, Name = "Pro1", Price = 10},
                new Product {ID = 2, Name = "BAse2", Price = 12}
            };
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
                OnPropertyChanged("SelectedProduct");
            }
        }
        public ObservableCollection<Product> Products
        {
            get
            {
                return m_Products;
            }
            set
            {
                m_Products = value;
            }
        }
        ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(param => AddItem());
                }
                return _addCommand;
            }
        }
        ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(param => DeleteItem((Product)param));
                }
                return _deleteCommand;
            }
        }
        private void DeleteItem(Product product)
        {
            if (m_Products.Contains(product))
            {
                m_Products.Remove(product);
            }
        }
        private void AddItem()
        {
            m_Products.Add(new Product());
          
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
