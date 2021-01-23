     ObservableCollection<User> users = new  ObservableCollection<User>();
    private void Add_Click(object sender, RoutedEventArgs e)
    {
        users.Add(new User(){Id = Int.Parse(tb1.Text), Name = tb2.Text, Salary = Int.Parse(tb3.Text)});
    }
    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        users.RemoveAt(dgSample.SelectedIndex);
    }
    private void Get_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(( (User)dgSample.Items[dgSample.SelectedIndex]).Name);
    }
