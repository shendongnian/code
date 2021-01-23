        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
          if(DGV.Rows.Count>0 && DGV.Columns.Count>0)
          {
            foreach (DataGridViewRow r in DGV.Rows)
            {
              if(condition)
              {
                DataGridViewCheckBoxCell cell = r.Cells[ColumnIndexToColor];
                cell.Style.BackColor = Color.AliceBlue;
              }
            }
          }
        }
    
    
