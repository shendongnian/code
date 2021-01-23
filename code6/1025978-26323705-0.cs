    private void button_Save_Customer_Click(object sender, EventArgs e)
    {
        sqlString = Properties.Settings.Default.ConnectionString;
        SqlConnection sqlConnection = new SqlConnection(sqlString);
        //            SQL = "SELECT Customer_ID FROM customer";
        string SQL = @"UPDATE Customer_Ship SET Customer_Ship_Address = @Customer_Ship_AddressTextBox WHERE Customer_ID = @Customer_IDTextBox";
        try
        {
            SqlCommand sqlCommand = new SqlCommand(SQL, sqlConnection);
            // Here the value of the condition where in case you want to update
            // the row with a specific Customer_ID ...
            string Customer_IDTextBox = "my customer id..."; 
            // Here the text you will use to update
            string Customer_Ship_AddressTextBox = "new value...";
            sqlCommand.Parameters.AddWithValue("@Customer_IDTextBox", Customer_IDTextBox);
            sqlCommand.Parameters.AddWithValue("@Customer_Ship_AddressTextBox", Customer_Ship_AddressTextBox);
            sqlCommand.CommandText = SQL;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Record Updated");
        }
        catch (Exception err)
        {
            MessageBox.Show(err.Message);
        }
    }
