    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if(dataGridView.Columns[e.ColumnIndex].ReadOnly != true)
        {       
            dataGridView.CurrentCell.Value = true;
            dataGridView.NotifyCurrentCellDirty(true);
        }
    }
    
