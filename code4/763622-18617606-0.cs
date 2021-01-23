     private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 1 && dataGridView1[1, e.RowIndex].Value.ToString() != "")
                    dataGridView1[2, e.RowIndex].ReadOnly = false;
                else
                    dataGridView1[2, e.RowIndex].ReadOnly = true;
            }
        }
    
