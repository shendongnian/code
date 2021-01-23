     foreach (DataGridViewRow dgRow in dataGridView1.Rows)
     {
          if (dgRow.Cells[7].Value != null) //Check for null reference
          {
                 string conte = dgRow.Cells[7].Value.ToString();
                 dgRow.Cells[7].Style.BackColor = 
                       (!string.IsNullOrEmpty(conte)) ?  //Check for empty string
                           Color.Orange : 
                           Color.LightCyan; 
          }
     }
    
