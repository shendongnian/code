    private void buttonRemove_Click(object sender, RoutedEventArgs e)
    {
       comboBoxTools.Items.Remove(comboBoxTools.SelectedItem);
       toolList.Remove(comboBoxTools.SelectedItem);
    }
