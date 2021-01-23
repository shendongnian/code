    public void checkUsername(object source, ServerValidateEventArgs args)
    {
         string connString = "...";
        string cmdText = "SELECT COUNT(*) FROM Users WHERE username = @username";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                cmd.Parameters.AddWithValue("@username", TextBoxUsername.Text);
                int count = (int)cmd.ExecuteScalar();
                args.IsValid = (0 == count); 
            }
        }
    }
