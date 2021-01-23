    const string qry = "SELECT SiteNum FROM WorkTable WHERE WTName LIKE @wtName";
    using (SQLiteConnection con = new SQLiteConnection(HHSUtils.GetDBConnection()))
    {
        con.Open();
        SQLiteCommand cmd = new SQLiteCommand(qry, con);
        cmd.Parameters.Add(new SQLiteParameter("wtName", tableName + "%"));
        siteNum = Convert.ToInt32(cmd.ExecuteScalar());
    }
