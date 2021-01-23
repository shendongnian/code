    using (OdbcCommand com = new OdbcCommand(
        "SELECT ColumnWord FROM OkieTable WHERE MagicKey = ?", con))
    {
        com.Parameters.AddWithValue("@var", paramWord);
        using (OdbcDataReader reader = com.ExecuteReader())
        {
    	while (reader.Read())
    	{
    	    string word = reader.GetString(0);
    	    // Word is from the database. Do something with it.
    	}
        }
    }
