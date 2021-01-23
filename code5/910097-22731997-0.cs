    using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["preconn"].ToString()))
    {
    	try
    	{
    		SqlCommand com = new SqlCommand("select * from slab where salbn=@salbn", con);
    		com.Parameters.Add("@salb", DropDownList1.SelectedItem.Text);
    
    		con.Open();
    
    		using(SqlDataReader reader = com.ExecuteReader())
    		{
    			if (reader.Read())
    			{
    				TextBox12.Text = reader["basic"].ToString();
    				TextBox13.Text = reader["hra"].ToString();
    				TextBox15.Text = reader["trvl"].ToString();
    				TextBox16.Text = reader["mdeca"].ToString();
    				TextBox18.Text = reader["atnd"].ToString();
    				TextBox20.Text = reader["tote"].ToString();
    				TextBox21.Text = reader["salbn"].ToString();
    			}
    		}
    	}
    	catch (Exception e)
    	{
    	}
    	finally
    	{
    		con.Close();
    	}
    }
