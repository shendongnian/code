    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var viewModel = (ViewModelType)this.DataContext;
        foreach(var item in viewModel.MyItems)
        {
            if(item.BODelivered)
            {
                MessageBox.Show("Checked");
            }
        }
    }
