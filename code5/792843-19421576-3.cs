    ObservableCollection<User> users = new  ObservableCollection<User>();
    public MainWindow()
    {
        users = new List<User>();
        users.Add(new User() { Id = 101, Name = "gin", Salary = 10 });
        users.Add(new User() { Id = 102, Name = "alen", Salary = 20 });
        users.Add(new User() { Id = 103, Name = "scott", Salary = 30 });
        
        InitializeComponent();
        dgsample.ItemsSource = users;
    }
    private void Add_Click(object sender, RoutedEventArgs e)
    {
        users.Add(new User(){Id = Int.Parse(tb1.Text), Name = tb2.Text, Salary = Int.Parse(tb3.Text)});
    }
    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        users.RemoveAt(dgSample.SelectedIndex);
    }
    
    // you can get what you need just selected proper User proprety
    private void Get_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(( (User)dgSample.Items[dgSample.SelectedIndex]).Name);
    }
