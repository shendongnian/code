    private void dgv1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          var columnname = "AreaCode";
         if (e.ColumnIndex == dgv1.Columns[columnname].Index)
            {
                //Get the datagridview cell
                DataGridViewCell cell = dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell != null)
                {
                 this.dgv1.Columns["AreaCode"].DefaultCellStyle.Format = "N0";
                }
    
            }
    
        }
    
