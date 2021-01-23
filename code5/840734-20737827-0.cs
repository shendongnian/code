RowEnter
    private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
    {     
      //Set the selection mode to cell
      dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
    }
CellBeginEdit
    private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
       //set the current cell to be edited to cell in index 1
       dataGridView1.CurrentCell = dataGridView1[1, e.RowIndex];
    }
