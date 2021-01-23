    private string lastValue = null;
    private void TextBox_LostFocus(object sender, RoutedEventArgs e) //Lost Focus
    {
        bool valueChanged = ( lastvalue != TextBox.Text );
        lastValue = TextBox.Text;
        if (string.IsNullOrEmpty(TextBox.Text))
            TextBox.Text = "Default Record";
        else if (Regex.IsMatch(TextBox.Text, @"^\d+$") == false && valueChanged )
        {
            MessageBox.Show("Illegal character in list.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            TextBox.Focus();
        }
    }
