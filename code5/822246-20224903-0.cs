    using (SqlConnection cn = new SqlConnection("Server=;Database=;User Id=naljalid;Password="))
    using (SqlCommand cmd = new SqlCommand("SELECT UserName FROM tblLoginProject WHERE UserName = @username AND Password = @password", cn))
    {
        cn.Open();
        
        cmd.Parameters.AddWithValue("@username", tbxUserName.Text);
        cmd.Parameters.AddWithValue("@password", tbxPassword.Text);
        
        var result = cmd.ExecuteScalar() as string;
        if (string.IsNullOrEmpty(result))
        {
            // user was not found
        }
        else
        {
            // user was found
        }
    }
