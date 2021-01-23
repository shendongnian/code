    if (shouldNotFilter)
    {
         row.Visible = true;
    }
    else
    {
        if(row.Cells[1].Value == null)
        {
           row.Visible = false;
        }
        else
        {
             if (!string.Equals(row.Cells[1].Value.ToString(), driverNo.Text, StringComparison.OrdinalIgnoreCase))
             {
                  row.Visible = false;
             }
             else
             {
                  row.Visible = true;
             }
        }
    }
