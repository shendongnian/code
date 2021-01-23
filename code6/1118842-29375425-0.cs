    private void AddIndexCol()
    {
      DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
      col.Name = "Index";
      col.HeaderText = "Index";
      col.ReadOnly = true;
      col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
      DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
      cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      col.CellTemplate = cell;
      this.dataGridView1.Columns.Insert(0, col);
    }
