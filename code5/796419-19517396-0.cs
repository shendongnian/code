    private void newBtn_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        if(btn != null)
        {
            MessageBox.Show(btn.Name);
        }
    }
