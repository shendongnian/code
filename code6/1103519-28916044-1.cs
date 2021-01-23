    private void txt_LostFocus(object sender, RoutedEventArgs e)
    {
        int value1;
        int value2;
        TextBox textBox = (TextBox)sender;
    
        if (textBox.Tag is bool && (bool)textBox.Tag)
        {
    
            if (Int32.TryParse(textBox.Text, out value1))
            {
                if (String.IsNullOrEmpty(sum.Text))
                {
                    sum.Text = textBox.Text;
                }
                else
                {
                    Int32.TryParse(sum.Text, out value2);
                    sum.Text = Convert.ToString(value1 + value2);
                }
            }
    
            textBox.Tag = false;
        }
    }
    
    private void txt_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        textBox.Tag = true;
    }
