    for (int i = 0; i < dgResults.Items.Count; i++)
    {
        var x = dgResults.GetCell(i, 0).Content as System.Windows.Controls.ComboBox;
        x.SelectedIndex = comboBoxItemsSource.Items.Count - 1;
    }
