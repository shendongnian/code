    private void AddCheckColumn()
    {
      DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
      col.Name = "Checked";
      if (!this.dataGridView1.Columns.Contains(col.Name))
      {
        this.dataGridView1.Columns.Add(col);
        string values = "true;false;true;false;";
        List<string> vals = values.TrimEnd(';').Split(';').ToList();
        foreach (string val in vals)
        {
          DataGridViewRow row = new DataGridViewRow();
          row.CreateCells(this.dataGridView1);
          DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
          cell.Value = val == "true";
          this.dataGridView1.Rows.Add(row);
        }
      }
    }
