    private void dataGridViewInputFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == 1 || e.ColumnIndex == 2)
        {
            if (Convert.ToInt16(dataGridViewInputFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == 0)
            {
                if (e.ColumnIndex == 1)
                {
                    dataGridViewInputFiles.Rows[e.RowIndex].Cells[2].Value = 0;
                }
                else if (e.ColumnIndex == 2)
                {
                    dataGridViewInputFiles.Rows[e.RowIndex].Cells[1].Value = 0;
                }
            }
            else
            {
                if (e.ColumnIndex == 1)
                {
                    dataGridViewInputFiles.Rows[e.RowIndex].Cells[2].Value = 1;
                }
                else if (e.ColumnIndex == 2)
                {
                    dataGridViewInputFiles.Rows[e.RowIndex].Cells[1].Value = 1;
                }
            }
        }
    }
