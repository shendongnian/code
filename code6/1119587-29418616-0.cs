    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      DataGridViewCheckBoxCell cell = this.dataGridView1.CurrentCell as DataGridViewCheckBoxCell;
      if (cell != null && !cell.ReadOnly)
      {
        cell.Value = cell.Value == null || !((bool)cell.Value);
        this.dataGridView1.RefreshEdit();
        this.dataGridView1.NotifyCurrentCellDirty(true);
      }
    }
----------
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      this.dataGridView1.RefreshEdit();
    }
