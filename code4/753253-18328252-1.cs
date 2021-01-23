    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
            Grid1.MouseUp += new MouseButtonEventHandler(Grid1_MouseUp);
    }
    private void Grid1_MouseUp(object sender, MouseButtonEventArgs e)
    {
            MessageBox.Show("Mouseup");
    }
 
    
