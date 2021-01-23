    private void buttonRemove_Click(object sender, RoutedEventArgs e)
    {
        if(combobox.SelectedItem != null)
            Tools.remove((Tool) combobox.SelectedItem);
        else
            System.Windows.Forms.MessageBox.Show("No Item choosed");
    }
