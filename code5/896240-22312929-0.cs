    public event RoutedEventHandler ClickedInUserControl;
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
            if (ClickedInUserControl != null)
            {
                ClickedInUserControl(this, new RoutedEventArgs());
            }         
    }
