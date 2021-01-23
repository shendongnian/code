    private void MyDataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
    {
        DataGrid dataGrid = sender as DataGrid;
        if (e.EditAction == DataGridEditAction.Commit)
        {
            if (e.Column.Header.Equals("Variables"))
            {
                TextBox textBox = e.EditingElement as TextBox;
                MessageBox.Show(textBox.Text);
            }
            else if (e.Column.Header.Equals("IsLive"))
            {
                CheckBox checkBox = e.EditingElement as CheckBox;
                MessageBox.Show(checkBox.IsChecked.ToString());
            }
        }
    }
