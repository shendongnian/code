    private void MyDataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
    {
        DataGrid dataGrid = sender as DataGrid;
        if (e.EditAction == DataGridEditAction.Commit)
        {
            if (e.Column.Header.ToString() == "Variables")
            {
                TextBox textBox = e.EditingElement as TextBox;
                MessageBox.Show(textBox.Text);
            }
            if (e.Column.Header.ToString() == "IsLive")
            {
                CheckBox checkBox = e.EditingElement as CheckBox;
                MessageBox.Show(checkBox.IsChecked.ToString());
            }
        }
    }
