        public MainWindowViewModel()
        {
            FirstCollection = new ObservableCollection<WindowItem>();
            SecondCollection = new ObservableCollection<WindowItem>();
            ThirdCollection = new ObservableCollection<WindowItem>();
            var windowItem = new WindowItem();
            SecondCollection.Add(windowItem.Clone());
            FirstCollection.Add(windowItem.Clone());
            FirstCollection.CollectionChanged += FirstCollectionChanged;
        }
