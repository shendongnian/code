    string sCommand = "INSERT INTO storage (@number, @word1, @word2)";
    using (MySqlConnection mConnection = new MySqlConnection(ConnectionString))
    {
        mConnection.Open();
        using (MySqlCommand myCmd = new MySqlCommand(sCommand, mConnection))
        {
            myCmd.Parameters.Add(new MySqlParameter("@number", number));
            myCmd.Parameters.Add(new MySqlParameter("@word1", word1));
            myCmd.Parameters.Add(new MySqlParameter("@word2", word2));
            myCmd.ExecuteNonQuery();
        }
    }
