    private void dataGrid1_PreviewDeleteCommandHandler(object sender, ExecutedRoutedEventArgs e)
    {
        if (e.Command == DataGrid.DeleteCommand)
        {
            //Get the row data before deleting 
            DataGridRow selectedRow = (DataGridRow)dataGrid1.ItemContainerGenerator.ContainerFromIndex(dataGrid1.SelectedIndex);
            DataRowView rv = (DataRowView)selectedRow.Item;
            // First cell in the row is usually the ID of the row (you can modify that in your database)
            string recNoToDelete = rv.Row[0].ToString();
            if (recNoToDelete == "")
            {
                e.Handled = false;
                return;
            }
            if (MessageBox.Show("Are you sure to delete this row?","", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                SqlConnection Conn = new SqlConnection(connectionString);
                SqlCommand Comm = new SqlCommand("", Conn);
                // Delete
                Comm = new SqlCommand("", Conn);
                Comm.CommandText = "Delete from Table where field=@field";
                Comm.Parameters.AddWithValue("@field", recNoToDelete);
                Conn.Open();
                Comm.ExecuteNonQuery();
                Conn.Close();
                // Reload all the data again in the datagrid after deletion of that record
                ReloadData();
                }
                else
                {
                    //record is not valid or has been deleted or manipulated
                    //cancel the delete operation
                    e.Handled = true;
                    return;
                }
        }
    }
