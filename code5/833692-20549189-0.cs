    using (SqlCeConnection myConnection = new SqlCeConnection(@"Data Source=|DataDirectory|\" + FileName + ".sdf;Password=Z123")) 
    {
        string query = "create table EXP(ID int, source int)";
        SqlCeCommand cmd = new SqlCeCommand(query, connection);  // use SqlCeCommand here!!
        cmd.con.open();
        cmd.ExecuteNonQuery();
    }
