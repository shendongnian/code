    string selection = null;
    private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ComboBox1.SelectedIndex != -1)
        {
            //selection = ComboBox1.SelectedItem.ToString();
             selection = (ComboBox1.SelectedItem as ComboBoxItem).Content.ToString();
        }
    }
