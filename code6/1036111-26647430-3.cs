    string dbConnectionString = @"Data Source=Sample.s3db;Version=3;";
    try
    {
        SQLiteConnection sqlite_con = new SQLiteConnection(dbConnectionString);
        sqlite_con.Open();
        string query = "select * from test;";
        SQLiteCommand sqlite_cmd = new SQLiteCommand(query, sqlite_con);
        SQLiteDataReader dr = sqlite_cmd.ExecuteReader();
        while (dr.Read())
        {
            MessageBox.Show(dr.GetString(1));
        }
        sqlite_con.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }
