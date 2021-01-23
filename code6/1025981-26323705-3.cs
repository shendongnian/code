    private void button_Save_Customer_Click(object sender, EventArgs e)
    {
        sqlString = Properties.Settings.Default.ConnectionString;
        SqlConnection sqlConnection = new SqlConnection(sqlString);
        try
        {
            int customer_Ship_ID;
            if(int.TryParse(customer_Ship_IDTextBox.Text, out customer_Ship_ID))
            {
                string customer_Ship_Address = customer_Ship_AddressTextBox.Text;
                // Customer_Ship: Database's table
                // Customer_Ship_Address, Customer_Ship_ID: fields of your table in database
                // @Customer_Ship_Address, @Customer_Ship_ID: parameters of the sqlcommand
                // customer_Ship_ID, customer_Ship_Address: values of the parameters
                SQL = "UPDATE Customer_Ship SET Customer_Ship_Address = @Customer_Ship_Address WHERE Customer_Ship_ID = @Customer_Ship_ID";
                SqlCommand sqlCommand = new SqlCommand(SQL, sqlConnection);
                sqlCommand.Parameters.AddWithValue("Customer_Ship_ID", customer_Ship_ID);
                sqlCommand.Parameters.AddWithValue("Customer_Ship_Address", customer_Ship_Address);
                sqlCommand.CommandText = SQL;
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Record Updated");
            }
            else
            {
                // The id of the textbox is not an integer...
            }
        }
        catch (Exception err)
        {
                MessageBox.Show(err.Message);
        }
    }
