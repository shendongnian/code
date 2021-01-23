        public MainWindowViewModel()
        {
            FirstCollection = new ObservableCollection<WindowItem>();
            SecondCollection = new ObservableCollection<WindowItem>();
            ThirdCollection = new ObservableCollection<WindowItem>();
            var windowItem = new WindowItem();
            FirstCollection.Add(windowItem);            
            SecondCollection.Add(windowItem.Clone());
            
            // Register to collection changes notifications
            FirstCollection.CollectionChanged += FirstCollectionChanged;
        }
