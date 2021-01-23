    public MainWindow()
    {
        _UsersList.Add(new User {Name = "Mike"});
        _UsersList.Add(new User { Name = "Nick" });
        DataContext = this;
        InitializeComponent();
        listbox1.ItemsSource = _UsersList;
    }
