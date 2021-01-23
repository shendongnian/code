        public MainWindowViewModel()
        {
            FirstCollection = new ObservableCollection<WindowItem>();
            SecondCollection = new ObservableCollection<WindowItem>();
            ThirdCollection = new ObservableCollection<WindowItem>();
            var windowItem = new WindowItem();
            SecondCollection.Add(windowItem);
            FirstCollection.Add(windowItem);
        }
