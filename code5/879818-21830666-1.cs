    private void Handler(object sender, RoutedEventArgs e)
    {
       if(e.OriginalSource is Button)
       {
           //Your code
       }
       else
       {
          e.Handled = true; 
       }
    }
