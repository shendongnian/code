    using(var conn = new MySqlConnection(ConnectionString)
    {
    	conn.Open();
    	using(var cmd = new MySqlCommand())
    	{
    		cmd.Connection = conn;
    		cmd.CommandText = "SELECT bug_name, bug_submitted_by FROM bugs WHERE bug_name = @name";
    		cmd.Parameters.AddWithValue("@name", this.txt_bug_name.Text);
    		using(var reader = cmd.ExecuteReader())
    		{
    			if(reader.Read())
    			{
    				// Will fill in next
    			}
    		}
    	}
    }
