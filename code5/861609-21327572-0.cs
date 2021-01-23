    DataTable dt = new DataTable();
    dt.Columns.Add("values",typeof(string));
    foreach (DataGridViewRow gridRow in dataGridView_settings.Rows)
    {
          for (int i = 0; i < dataGridView_settings.Columns.Count; i++)
          {
              DataRow dtRow = dt.NewRow();
              dtRow[0] = gridRow.Cells[i].Value;
              dt.Rows.Add(dtRow);
          }
    }
