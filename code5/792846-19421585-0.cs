            public MainWindow()
            {
                InitializeComponent();
                Users = new ObservableCollection<User>;
                Users.Add(new User() {Id = 101, Name = "gin", Salary = 10});
                Users.Add(new User() {Id = 102, Name = "alen", Salary = 20});
                Users.Add(new User() {Id = 103, Name = "scott", Salary = 30});
    
                dgsample.ItemsSource = Users;
            }
    
            private ObservableCollection<User> Users { get; set; }
    
            private void Add_Click(object sender, RoutedEventArgs e)
            {
                Users.Add(new User() {Id = int.Parse(tb1.Text), Name = tb2.Text, Salary = tb3.Text});
            }
