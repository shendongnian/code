    private void newBtn_Click(object sender, RoutedEventArgs e)
    {
            var button = sender as Button;
            var buttonNumber = button.Name.Remove(0, 6);
    
            MessageBox.Show("Hello" + buttonNumber);
    }
