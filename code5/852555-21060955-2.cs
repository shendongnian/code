    button1.Enabled = false;
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
       DataGridViewCheckBoxCell cell = row.Cells[colCheckIndex] as DataGridViewCheckBoxCell;
       if (cell.Value == cell.TrueValue){
          button1.Enabled = true;
          break;
        }
    }
