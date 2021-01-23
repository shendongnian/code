    void DisplayLowQuantityItems()
    {
    	MySqlConnection con = new SqlConnection("Data Source=christina\\sqlexpress;
    	Initial Catalog=cafe_inventory;User ID=sa;Password=tina;");
    	MySqlCommand command = new MySqlCommand("Select pname from inventory 
    	                                              where qt < 5", con);
    	MySqlDataReader reader = commad.ExecuteReader();
    	StringBuilder productNames= new StringBuilder();
    	while(reader.Read())
    	{
    		productNames.Append(reader["pname"].ToString()+Environment.NewLine);
    	}
    	con.Close();
    	MessageBox.Show("Following Products quantity is lessthan 5\n"+productNames);
    }
