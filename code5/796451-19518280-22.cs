    public MainWindow()
	{
        CurrUser = new User();
	    users = new ObservableCollection<User>();
	    users.Add(new User() { Id = 101, Name = "gin", Salary = 10 });
	    users.Add(new User() { Id = 102, Name = "alen", Salary = 20 });
	    users.Add(new User() { Id = 103, Name = "scott", Salary = 30 });
	    users.Add(new User() { Id = 104, Name = "a", Salary = 30 });
    
        InitializeComponent();
        Grid.ItemsSource = users;
    }
