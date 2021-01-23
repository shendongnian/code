    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedID = DropDownList1.SelectedItem.Value;
        SqlCommand theCommand = new SqlCommand("SELECT * FROM Customers.dbo.Customer WHERE CustomerID = @CustomerID", connection);
        theCommand.Paramters.AddWithValue("@CustomerID", selectedId);
        theCommand.CommandType = CommandType.Text;
        using (SqlDataReader theReader = theCommand.ExecuteReader())
        {
            if (theReader.HasRows)
            {
                // Get the first row
                theReader.Read();
                // Set the text box values
                CustomerName.Text = theReader.GetString(0);
                ...
            }
        } 
    }
