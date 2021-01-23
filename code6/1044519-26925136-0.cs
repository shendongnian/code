     foreach (DataGridViewRow row in GdvDetails.Rows)
    {
      var cellValue = row.Cells["Bunch Component"].Value;
      if (cellValue != null)
     { 
      if ( cellValue.ToString().Contains(txtSearch.Text))
      {
          GdvDetails.Rows[row.Index].DefaultCellStyle.BackColor = Color.Yellow;
      }
      else
      {
          GdvDetails.Rows[row.Index].DefaultCellStyle.BackColor = Color.Empty;
      }
    }
    }
