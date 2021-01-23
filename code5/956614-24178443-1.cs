    private void B_Click(object sender, RoutedEventArgs e)
    {
       Button btn = (Button)sender;
       string src = btn.Name.ToString();
       string identifier= src.Substring(1);
       foreach (var btn in FindVisualChildren<Button>(this).Where(b => b.Name.EndsWith(identifier)))
       {
          if(btn.Name.StartsWith("G"))
            btn.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
       }
    }
