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
    				// We got a row
    				if(reader.GetString("bug_submitted_by").Equals(this.lbl_user.Text))
    				{
    					// If the username matches delete it
    					using(var cmd2 = new MySqlCommand())
    					{
    						cmd2.Connection = conn;
    						cmd2.CommandText = "DELETE FROM bugs WHERE bug_name = @name";
    						cmd2.Parameters.AddWithValue("@name", this.txt_bug_name.Text);
    						cmd2.ExecuteNonQuery();
    						lbl_message.Text = "Bug Deleted!";
    					}
    				}
    				else
    				{
    					// Username doesn't match
    					lbl_message.Text = "Incorrect user!";
    				}
    			}
    			else
    			{
    				// We didn't get a row
    				lbl_message = "Bug Doesn't Exist!";
    			}
    		}
    	}
    }
