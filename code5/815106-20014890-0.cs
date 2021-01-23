    foreach(DataGridViewRow row in dataGridView1.Rows)
                    {
    
                      if(!row.IsNewRow)
                      {
                         if (!(Convert.ToDateTime(row.Cells[7].Value) - DateTime.Today).Days <= 0)
                         {
                           dataGridView1.Rows.Remove(row);
                         }
                      }
    
                    }
       
