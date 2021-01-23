     public MainWindow()
    {
         InitializeComponent();
        _UsersList.Add(new User {Name = "Mike"});
        _UsersList.Add(new User { Name = "Nick" });
        listbox1.ItemsSource = _UsersList;
        DataContext = this;
        
