    private int previouslySelected = -1;
    
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
    		// Minus here - Something was selected before
    		if (previouslySelected != -1)
    		{
    		
    		}
    		// Something has been selected
    		if (CheckBoxList1.SelectedIndex)
    		{    
    
    			decimal CompraTotal = 0;
    			MySqlConnection connection = new MySqlConnection(GlobalVars.mysql);
    			connection.Open();
    	
    			MySqlCommand command = connection.CreateCommand();
    			command.CommandText = "QUERY";
    			command.Parameters.AddWithValue("?GUID", Session["GUID"]);
    			command.Parameters.AddWithValue("?Name", CheckBoxList1.SelectedValue);
    			MySqlDataReader reader = command.ExecuteReader();
    			decimal Price = 0;
    			while (reader.Read())
    			{
    				Price = Convert.ToDecimal(reader["Price"]);
    			}	
    	
    			Total = Convert.ToDecimal(Session["Total"]);
    			CompraTotal = CompraTotal + Price;
    			Session["Total"] = Total;    
    		}
    		
    		previouslySelected = CheckBoxList1.SelectedIndex;
    	}
