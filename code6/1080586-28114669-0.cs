    string customer_id = variables.cid;
    customerID_txt.Text = customer_id;
    string constring2 = "datasource=localhost;port=3306;username=root;password=root";
    
    using (MySqlConnection connection = new MySqlConnection(constring2))
    {
    	string query = "insert into artgallery.orders(customer_id, painting_id) values (@cutsomerId, @paintingId);";
    	
    	MySqlCommand command = new MySqlCommand(query, connection);
    
    	command.Parameters.Add(new MySqlParameter("customerId", int.Parse(this.customerID_txt.Text)));
    	command.Parameters.Add(new MySqlParameter("paintingId", int.Parse(this.pID_txt.Text)));
    
        command.Connection.Open();
        command.ExecuteNonQuery();
    }
