    using(SqlConnection Connection = new SqlConnection(....))
    {
        try
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM Logins 
                                            WHERE Username=@uname and 
                                            Password=@pass", Connection);
            cmd.Parameters.AddWithValue("@uname", txtUsername.Text);
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
            int result = (int)cmd.ExecuteScalar();
            if(result > 0)
                MessageBox.Show("Login Success");
            else
                MessageBox.Show("Incorrect login");
        }
        catch(Exception ex)
        {
            MessageBox.Show("Unexpected error:" + ex.Message);
        }
    }
