    private void Combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = (sender as ComboBox);
        if ((comboBox.SelectedItem as ComboBoxItem).Content.ToString() == "Value 2")
        {
            Combo2.Items.Add("Value 5");
        }
    } 
