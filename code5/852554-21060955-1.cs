    button1.Enabled = false;
    for (int i = 0; i <= Datagridview1.RowCount - 1; i++)
    {
    
        if (Convert.ToBoolean(Datagridview1.Rows[i].Cells["chkcol"].Value))
        {
            button1.Enabled = true;
            break;
        }
    }
 
