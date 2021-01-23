    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button btn = sender as Button;
        Debug.WriteLine(string.Format("{0}.DataContext: {1}", btn.Name, btn.DataContext));
        Debug.WriteLine(string.Format("{0}.Content: {1}", btn.Name, btn.Content));
    }
