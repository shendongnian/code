    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        DataGrid row = (DataGrid)myGrid.SelectedItems[1]; // <--- 2nd item, not 2nd column!
        System.Windows.MessageBox.Show(row);
    }
