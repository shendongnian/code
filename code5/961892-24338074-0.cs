    public DataTable opencon(PAL.property objpal)
    {
        string query = "Select UserId,Firstname,UserType from TBL_USER_LOGIN where Username=? and Password=? and Status=1";
        OleDbCommand objcmd = new OleDbCommand();
        objcmd.CommandText = query;
        objcmd.Connection = oldbcon;
        oldbcon.Open();
        objcmd.Parameters.Add("@username", OleDbType.VarChar).Value = objpal.username;
        objcmd.Parameters.Add("@password", OleDbType.VarChar).Value = objpal.Password;
        DataTable dt = new DataTable();
        OleDbDataAdapter adp = new OleDbDataAdapter(objcmd);
        adp.Fill(dt);
        return dt;
    }
