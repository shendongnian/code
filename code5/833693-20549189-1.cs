    using (SqlCeConnection myConnection = new SqlCeConnection(@"Data Source=|DataDirectory|\" + FileName + ".sdf;Password=Z123")) 
    {
        string query = "create table EXP(ID int, source int)";
        // use SqlCeCommand here!! Also: use the "myConnection" SqlCeConnection you're 
        // opening at the top - don't use something else.....
        SqlCeCommand cmd = new SqlCeCommand(query, myConnection);
        myConnection.open();
        cmd.ExecuteNonQuery();
        myConnection.Close();
    }
