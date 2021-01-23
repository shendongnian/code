    // Test class with a single string property
    private class MyData
    {
        public String Name { get; set; }
        public MyData(String name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        // Create some test data
        ObservableCollection<MyData> names = new ObservableCollection<MyData>();
        names.Add(new MyData("Name 1"));
        names.Add(new MyData("Name 2"));
        names.Add(new MyData("Name 3"));
        MyListView.ItemsSource = names;
    }
    private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = true;
    }
    private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
       Clipboard.SetText(MyListView.SelectedItem.ToString());
    }
