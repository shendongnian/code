    class MainWindowViewModel
    {
        public ObservableCollection<KeyValuePair<string, int>> Me { get; private set; }
    
        public MainWindowViewModel(Model model)
        {
            this.model = model;
            // Instantiate in the constructor, then add your values
            Me = new ObservableCollection<KeyValuePair<string, int>>();
    
            Me.Add(new KeyValuePair<string, int>("test", 1));
            Me.Add(new KeyValuePair<string, int>("test1", 1000));
            Me.Add(new KeyValuePair<string, int>("test2", 20));
            Me.Add(new KeyValuePair<string, int>("test3", 500));
        }
    }
