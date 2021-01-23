    foreach (DataGridViewRow row in DataGridView1.Rows)
    
    { 
    
    if  (row.Cells[8]==1)
      {
          row.Cells[8]=new DataGridViewImageCell();
          row.Cells[8].Value = (System.Drawing.Image)Properties.Resources.ok;
      }
    if  (row.Cells[8]==0)
      {
           row.Cells[8]=new DataGridViewImageCell();
           row.Cells[8].Value = (System.Drawing.Image)Properties.Resources.notOK;
      }
    }
