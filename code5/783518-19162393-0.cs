    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    	connection.Open();
    
    	SqlTransaction transaction;
    
    	// Start a local transaction.
    	transaction = connection.BeginTransaction("SampleTransaction");
    	
    	SqlCommand cmd = new SqlCommand("CREATE TABLE [dbo].[" + textBox8.Text + "_stock]("
    		+ "[date] [date] NOT NULL PRIMARY KEY CLUSTERED,"
    		+ "[openingstock] [int] NOT NULL,"
    		+ "[receipt] [int] NOT NULL,"
    		+ "[totalstock] [int] NOT NULL,"
    		+ "[sell] [int] NOT NULL,"
    		+ "[closingstock] [int] NOT NULL,"
    		+ ") ON [PRIMARY]", connectionsql);
    	
    	if (cmd.ExecuteNonQuery() <1) // no table created
    	{
    		transaction.Rollback();
    	}
    	else // no error
    	{
    		SqlCommand cmd1 = new SqlCommand("insert into " + textBox8.Text + "_stock values(@date,0,0,0,0,0)", connectionsql);
    		cmd1.Parameters.AddWithValue("date", dateTimePicker3.Value);
    
    		if (cmd1.ExecuteNonQuery() < 1) // no row inserted
    		{
    			transaction.Rollback();
    		}
    		else // no error
    		{
    			cmd1.Dispose();
    
    			SqlCommand cmd2 = new SqlCommand("insert into rate values ('" + textBox12.Text + "','" + textBox8.Text + "_stock','" + double.Parse(textBox7.Text) + "','" + comboBox4.SelectedItem + "')", connectionsql);
    			int z = cmd2.ExecuteNonQuery();
    			
    			if (z < 1) // no row inserted
    			{
    				transaction.Rollback();
    			}
    			else // no error
    			{
    				transaction.Commit(); // everything was OK, you can commit the results
    			}			
    			cmd2.Dispose(); 
    		}
    		cmd1.Dispose();
    	}
    	cmd.Dispose();
    }
