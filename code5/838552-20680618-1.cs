    List<bool> list = new List<bool>();
    foreach (GridViewRow row in grid.Rows)
    {
       if (((CheckBox)row.FindControl("chkboxid")).Checked)
       {
             list.Add(chkboxid.Checked);
       }            
       else
       {
         list.Add(chkboxid.Checked);
       }
    }
