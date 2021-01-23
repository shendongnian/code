    void dataGridView1_MouseUp(object sender, MouseEventArgs e)
    {            
        // Selected cells has only a readonly copy.
        foreach (DataGridViewCell item in dataGridView1.SelectedCells)
        {
            dataGridView1.Rows[item.RowIndex].Cells[item.ColumnIndex].Selected = false;
        }            
        // do your selection logic here
    }
