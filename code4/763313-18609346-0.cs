    try
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand("SELECT MAX(Account_No) + 1 FROM addcustomer", con))
        {
            con.Open();
            int result = (int)cmd.ExecuteScalar();
            textBox1.Text = result.ToString();
        }
    }
    catch (SqlException ex)
    {
        MessageBox.Show(ex.ToString()); // do you get any Exception here?
    }
