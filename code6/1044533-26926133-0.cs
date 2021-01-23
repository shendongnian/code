      foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                if (// condition for true)
                {
                    row.Cells[2].ReadOnly = true;
                }
            else// condition for fals)
                {
                    row.Cells[2].ReadOnly = false;
                }
           
            }
