    private void Create_Click(object sender, RoutedEventArgs e)
    {
        Window newCacheForm = new Window
        {
            Title = "Add New Cache Tag",
            Content = new TestUserControl(),
            DataContext = new TestModel()
        };
        var myBinding = new Binding();
        myBinding.Path = new PropertyPath("IsClose");
        newCacheForm.SetBinding(WindowCloseBehaviour.CloseProperty, myBinding);
        var result = newCacheForm.ShowDialog();
        if (result == false) 
        {
            MessageBox.Show("Close Window!");
        }
    }
