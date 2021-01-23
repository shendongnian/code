    void dataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
        {
            foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
            {
                if (cell.GetType() == typeof(DataGridViewImageCell))
                {
                    cell.Value = DBNull.Value;
                }
            }
        }
    }
