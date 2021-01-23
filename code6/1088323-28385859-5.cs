    foreach (DataGridViewRow row in dataGridView1.Rows) {
      foreach (DataGridViewCell cell in row.Cells) {
        sw.WriteLine(string.Join(";", cell.RowIndex.ToString(),
                                      cell.ColumnIndex.ToString(),
                                      GetColorName(cell.Style.BackColor)));
      }
    }
