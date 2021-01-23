    button1.Enabled = false;
    foreach (DataGridViewRow row in Datagridview1.Rows)
    {
        if (Convert.ToBoolean(row.Cells["chkcol"].Value))
          {
            button1.Enabled = true;
            break;
          }
      
    }
