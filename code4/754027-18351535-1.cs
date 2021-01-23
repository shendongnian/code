    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex > -1 && e.RowIndex > -1)
        {
            if (e.ColumnIndex == 3) // Save button
            {
                dataGridView1.SavePendingChanges(e.RowIndex);
            }
        }
    }
