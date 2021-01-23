    DataRowView rowView = (DataRowView)e.Row.DataItem;
    if(rowView["UserOFC"] != null)
    {
       try
       {
         (e.Row.FindControl("chk_UserOFC1") as CheckBox).Checked = Convert.ToBolean(rowView["UserOFC"].ToString());
       }
       catch
       {
       }
    }
