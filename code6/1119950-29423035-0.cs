    foreach (bool value in /* values loaded from the database */ )
    {
      var cell = this.dataGridView1.Rows[rowToLoad].Cells[columnToLoad];
      cell.Value = value;
      cell.ReadOnly = true;
    }
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (!this.dataGridView1.CurrentCell.ReadOnly)
      {
        /* Your color logic. */
      }
    }
      
