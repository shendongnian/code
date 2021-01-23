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
          User currentUser = (dgsample.Items[dgsample.SelectedIndex] as User); 
          int id = currentUser.Id; 
          string name = currentUser.Name; 
          string salary = currentUser.Salary;
    }
    private void Add_Click(object sender, RoutedEventArgs e)
    {
          users.Add(new User() { Id = 105, Name = "gin5", Salary = 100 });
    }
    private void Delete_Click(object sender, RoutedEventArgs e)
    {
       users.RemoveAt(0);
    }
