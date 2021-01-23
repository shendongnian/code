    private void dataGridView1_Resize(object sender, EventArgs e)
    {
      int width = this.dataGridView1.RowHeadersWidth;
      foreach (DataGridViewColumn col in this.dataGridView1.Columns)
      {
        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        width += col.Width;
      }
      if (width < this.dataGridView1.Width)
      {
        this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      }
    }
