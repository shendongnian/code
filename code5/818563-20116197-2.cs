    bool aCellWasSelected = false;
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        aCellWasSelected = true;
    }
    
    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
    {
        DataGridViewCell selectedCell = null;
        if (aCellWasSelected) 
        {
           selectedCell = dataGridView1.SelectedCells[0];
           
           //Do stuff with the given cell
        }
          
        aCellWasSelected = false;
    }
