    private void dataGridViewBrandDetails_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
            var dgv = sender as DataGridView;
            string s = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            for (int i = 0; i < dataGridViewBrandDetails.Rows.Count; i++)
            {
               
               if (dataGridViewBrandDetails.Rows[i].Cells[0] != null && dataGridViewBrandDetails.Rows[i].Cells[0].Value.ToString() == s
                {
                    MessageBox.Show("The value already existed in DataGridView.");
                }
    
            }   
    
            }
    
        }
