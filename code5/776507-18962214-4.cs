    // this is the constructor for your view (MyWindow.xaml.cs)
    private MyWindow( )
    {
        this.DataContext = new MyViewModel( );
    }
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
