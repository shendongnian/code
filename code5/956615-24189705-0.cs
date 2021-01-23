    private void B_Click(object sender, RoutedEventArgs e)
    {
        Button btn = (Button)sender;
        string src = btn.Name.ToString();
        string foo = "G" + src.Substring(1);
        Windows.UI.Xaml.Shapes.Rectangle rect = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName(foo);
        rect.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
    }
