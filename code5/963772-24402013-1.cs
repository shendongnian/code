    private void Button1_Click(object sender, RoutedEventArgs e)
    {
       Debug.Print("'Set DataContext' button clicked");       
        _vm.Text=tb.Text;
        tb.DataContext = _vm;
    }
