    using (SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder())
    {
        toDB = sqlCommandBuilder.QuoteIdentifier(toDB);
    }
    string query = "SELECT * FROM " + toDB + ".dbo.Products WHERE Name like @productName and SKU = @SKU";
    using (SqlConnection c = new SqlConnection(cs))
    using (SqlCommand command = new SqlCommand(query, c))
    {
        c.Open();
        command.Parameters.Add(new SqlParameter("@productName", SqlDbType.VarChar) { Value = productName });
        command.Parameters.Add(new SqlParameter("@SKU", SqlDbType.VarChar) { Value = SKU });
        //or command.Parameters.AddWithValue("@productName", productName);
        object o = (object)command.ExecuteScalar();
    }
