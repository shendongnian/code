    	try
    	{
    		SqlCeConnection con = new SqlCeConnection(Properties.Settings.Default.bazalocalaConnectionString);
    		con.Open();
    		//
    		// The following code uses an SqlCommand based on the SqlConnection.
    		//
    		using (SqlCeCommandcommand = new SqlCeCommand("CREATE TABLE taby(id int identity(1,1) primary key,nume nvarchar(10),prenume nvarchar(10) );", con))
    			{
    				command.ExecuteNonQuery();
    			}
    
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message);
    	}
    
