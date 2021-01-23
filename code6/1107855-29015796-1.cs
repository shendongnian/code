        public MainVM()
        {
            this.results= new ObservableCollection<resultType>();
            BindingOperations.EnableCollectionSynchronization(results, _itemsLock);
        }
        private static object _itemsLock = new object();
        public ObservableCollection<resultType> results{ get; set; }
