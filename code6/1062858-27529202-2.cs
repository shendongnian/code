    string pas;
    using (MySqlConnection cnn = new MySqlConnection(connectionString))
    {
    	string likvidavimas = string.empty;
    	if (pas == "SomeString")
    	{
    		likvidavimas = "DELETE FROM [Column1] WHERE ID=@ID";
    	}
    	else if (pas == "Column2")
    	{
    		likvidavimas = "DELETE FROM [Column2] WHERE ID=@ID";
    	}
    	likvidavimas.Parameters.AddWithValue("@ID", ID);
    	cnn.Open();
    	using (MySqlCommand cmd = new MySqlCommand(likvidavimas, cnn))
    	{
    		cmd.ExecuteNonQuery();
    	}
    }
