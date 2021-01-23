    private void Update(string num,string name, string quant, string location, string category, string numquery)
    {
        string query = "UPDATE Inventory SET Inventorynumber=@num, Inventory_Name=@name, " +
                       "Quantity =@qty,Location =@loc, Category =@cat " + 
                       "WHERE Inventorynumber =@numquery";
        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, serverconnection);
            cmd.Parameters.AddWithValue("@num", Convert.ToInt16(num));
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@qty", quant);
            cmd.Parameters.AddWithValue("@loc", location);
            cmd.Parameters.AddWithValue("@cat", category);
            cmd.Parameters.AddWithValue("@numquery", Convert.ToInt16(numquery));
            cmd.ExecuteNonQuery();
            this.CloseConnection();
            Bind();
        }
    }
