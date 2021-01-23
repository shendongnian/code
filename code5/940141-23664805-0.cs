    bool found;
    using (MySqlCommand checkCmd = con.CreateCommand())
    {
        checkCmd.CommandText = "SELECT id FROM table WHERE id = @RFID";
        checkCmd.Parameters.AddWithValue("RFID", myValue);
    
        using (MySqlDataReader reader = checkCmd.ExecuteReader())
        {
            found = reader.Read();
        }
    }
    if(!found) {
        using (MySqlCommand cmd = con.CreateCommand())
        {
            //try to create and execute insert query here
        }
    }
