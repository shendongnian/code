    protected void Loginbutton_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["RegConnectionString"].ConnectionString;
    
        using (var conn = new SqlConnection(connectionString))
        {
            var cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email=@Email AND Password=@Password",
                conn);
    
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Email", loginemail.Text);
            cmd.Parameters.Add("@Password", loginpassword.Text);
    
            conn.Open();
            int temp = Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
