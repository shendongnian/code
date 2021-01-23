        // This property took place of MethodParameter[0]
        public Subcategory SelectedSubcategory
        {
            get { return _selectedSubcategory; }
            set
            {
                Set(() => SelectedSubcategory, ref _selectedSubcategory, value);
                RaisePropertyChanged("Products");
            }
        }
        public IEnumerable<Product> Products
        {
            get
            {
                if (SelectedSubcategory != null)
                    return SelectedSubcategory.Products;
                return null;
            }
        }
