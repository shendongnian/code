      for (int row= 0; row < dgvLoadTable.Rows.Count; row++)
      {
        for (int col = 0; col < dgvLoadTable.Columns.Count; col++)
        {
          if (col == 2 || col == 4)
          {
            var temp = dgvLoadTable[col, row].Value;
            this.dgvLoadTable[col, row] = new DataGridViewComboBoxCell();
            dgvLoadTable[col, row].Value = temp;
            var items = dgvLoadTable.Rows.Cast<DataGridViewRow>()
                       .Where(r => r.Cells[0].Value != null)
                       .Where(r => r.Cells[col].Value != null)
                       .Select(r => r.Cells[col].Value)
                       .OrderBy(r => r).Distinct();
            ((DataGridViewComboBoxCell) dgvLoadTable[col, row])
                                       .Items.AddRange(items.ToArray());
           }
        }
     }                             
     dgvLoadTable.Refresh();
