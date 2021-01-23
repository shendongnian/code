    ObservableCollection<User> users = new  ObservableCollection<User>();
    public MainWindow()
    {
        InitializeComponent();
         
                    users.Add(new User() { Id = 101, Name = "gin", Salary = 10 });
                    users.Add(new User() { Id = 102, Name = "alen", Salary = 20 });
                    users.Add(new User() { Id = 103, Name = "scott", Salary = 30 });
                    dgsample.ItemsSource = users;
    }
    private void Get_Click(object sender, RoutedEventArgs e)
    {
         if (this.tb1.Text != string.Empty) { User currentUser = users.Single(select => select.Id == Int32.Parse(this.tb1.Text)); this.tb2.Text = currentUser.Name; this.tb3.Text = currentUser.Salary; } 
    }
    private void Add_Click(object sender, RoutedEventArgs e)
    {
          users.Add(new User() { Id = 105, Name = "gin5", Salary = 100 });
    }
    private void Delete_Click(object sender, RoutedEventArgs e)
    {
       users.RemoveAt(0);
    }
