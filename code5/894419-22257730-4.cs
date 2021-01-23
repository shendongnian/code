    private void Create_Click(object sender, RoutedEventArgs e)
    {
        Window newCacheForm = new Window
        {
            Title = "Add New Cache Tag",
            Content = new TestUserControl(),
            DataContext = new TestModel() // set the DataContext
        };
        var myBinding = new Binding();                // create a Binding
        myBinding.Path = new PropertyPath("IsClose"); // with property from DataContext
        newCacheForm.SetBinding(WindowCloseBehaviour.CloseProperty, myBinding); // for attached behavior 
        var result = newCacheForm.ShowDialog();
        if (result == false) 
        {
            MessageBox.Show("Close Window!");
        }
    }
