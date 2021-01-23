    button1.Enabled = false;
    foreach (DataGridViewRow row in Datagridview1.Rows)
    {
        if (((DataGridViewCheckBoxCell)row.Cells["chkcol"]).Value)
          {
            button1.Enabled = true;
            break;
          }
      
    }
