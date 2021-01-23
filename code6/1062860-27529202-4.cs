    string pas;
    using (MySqlConnection cnn = new MySqlConnection(connectionString))
    {
    	string likvidavimas = string.empty;
    	if (pas == "Table1")
    	{
    		likvidavimas = "DELETE FROM [Table1] WHERE ID=@ID";
    	}
    	else if (pas == "Table2")
    	{
    		likvidavimas = "DELETE FROM [Table2] WHERE ID=@ID";
    	}
    	likvidavimas.Parameters.AddWithValue("@ID", ID);
    	cnn.Open();
    	using (MySqlCommand cmd = new MySqlCommand(likvidavimas, cnn))
    	{
    		cmd.ExecuteNonQuery();
    	}
    }
