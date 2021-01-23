	using (SqlConnection connection = new SqlConnection(connectionString))
    {
		string commandText = "insert into Inventory (ID,Item,Gender,Qty,Price,FilePath) values(@ID, @Item, @Gender, @Qty, @Price, @FilePath)";
		
        SqlCommand command = new SqlCommand(commandText, connection);
        
		command.Parameters.Add("@ID", SqlDbType.Int).Value = txtID.Text;
		...
		command.Parameters.Add("@Price", SqlDbType.Decimal, 11, 4).Value = numPrice.Value;
		...
		
        connection.Open();
        command.ExecuteNonQuery();
    }
