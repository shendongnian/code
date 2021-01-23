    private void GetUser(string userId)
    {
        dbr.SelectString = "select name, gender,  address, contactno from userInfo where id = = '" + userId + "' --"; // return single row
        DataTable dt = dbr.GetTable();
        if (dt.Rows.Count > 0) 
        {
        DataRow row = dt.Rows[0];
        lbl_name = row["name"].ToString();
        lbl_gender = row["gender"].ToString();
        lbl_contact = row["contactno"].ToString();
        }
    }
