    using (SqlConnection connection = new SqlConnection(@"Data Source=SHKELQIM\SQLEXPRESS;Initial Catalog=E-Banking;Integrated Security=True"))
    using(SqlCommand command = new SqlCommand("SELECT * FROM ACCOUNTS WHERE Accountnumber= @Accountnumber", connection))
    {
        command.Parameters.AddWithValue("Accountnumber", accountnumber1.Text);
            connection.Open();
        using(SqlDataReader reader = command.ExecuteReader())
        {
            if (!reader.HasRows)
            {
                lblaccountnumber.Visible = true;
                lblaccountnumber.Text = "You don't have a bank account, you can't register to our website";
            }
        }
                        
    }
