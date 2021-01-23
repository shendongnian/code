    public void book_Click(object sender, RoutedEventArgs e)
    {
      // since we copied this already
      WebBrowser1.Navigate(((Button)sender).Content);
    }
