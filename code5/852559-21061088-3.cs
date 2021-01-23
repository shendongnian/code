    //This will always call the checking of checkbox whenever you ticked the checkbox in the datagrid
    private void DataGridView1_CellValueChanged(
        object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == [Your column index])
           CheckForCheckedValue();
    }
    
    private void CheckForCheckedValue()
    {
       button1.Enabled = false;
       foreach (DataGridViewRow row in Datagridview1.Rows)
       {
        if (((DataGridViewCheckBoxCell)row.Cells["chkcol"]).Value)
          {
            button1.Enabled = true;
            break;
          }
       }
    }
