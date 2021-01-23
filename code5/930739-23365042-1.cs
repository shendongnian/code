    if(e.Row.DataItem["UserOFC"] != null)
    {
       try
       {
         (e.Row.FindControl("chk_UserOFC1") as CheckBox).Checked = Convert.ToBolean(e.Row.DataItem["UserOFC"].ToString());
       }
       catch
       {
       }
    }
