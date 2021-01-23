    private void newBtn_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        if(btn != null)
        {
            if(btn.Tag is int)
                MessageBox.Show(String.Format("Hello{0}", btn.Tag));
        }
    }
