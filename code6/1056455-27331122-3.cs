    DateTime dt = new DateTime(1900, 1, 1);
    if(Convert.ToDateTime(ModCommon.sqldate(ModCommon.SetDate(JoinDate.Text))) <= dt)
    {
         dtpJoinDate.Text = "";
    }
