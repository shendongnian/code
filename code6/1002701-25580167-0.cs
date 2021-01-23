    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button obj = (Button)sender;
        MessageBox.Show(obj.Content.ToString());
    }
