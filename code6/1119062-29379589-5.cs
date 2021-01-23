    foreach (DataGridViewColumn dgCol in dataGridView1.Columns)
    {
          foreach (DataGridViewRow dgRow in dataGridView1.Rows)
          {
                if (dgRow.Cells[dgCol.Name].Value != null) //Check for null reference
                {
                       string conte = dgRow.Cells[dgCol.Name].Value.ToString();
                       dgRow.Cells[dgCol.Name].Style.BackColor = 
                            (!string.IsNullOrEmpty(conte)) ?  //Check for empty string
                                Color.Orange : 
                                Color.LightCyan; 
                }
          }
    }
