    private void newBtn_Click(object sender, RoutedEventArgs e)
    {
            var button = (Button)sender;
            var buttonNumber = button.Name.Remove(0, 6);
    
            MessageBox.Show("Hello" + buttonNumber);
    }
