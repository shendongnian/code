    protected void Button_Click(object sender, EventArgs e)
    {
        bool inputIsValid = true;
        var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        var userNameCmd = new SqlCommand("SELECT 1 FROM Table WHERE Name = @UserName", con);
        var emailCmd = new SqlCommand("SELECT 1 FROM Table WHERE Email = @UserEmail", con);
    
        con.Open();
        userNameCmd.Parameters.AddWithValue("@UserName", Name_id.Text);
        emailCmd.Parameters.AddWithValue("@UserEmail", Email_id.Text);
    
        using (var userNameReader = userNameCmd.ExecuteReader())
        {
            if (userNameReader.HasRows)
            {
                inputIsValid = false;
                Label1.Text = "User name already exists";
            }
        }
        using (var emailReader = emailCmd.ExecuteReader())
        {
            if (emailReader.HasRows)
            {
                inputIsValid = false;
                Label1.Text = "Email address already exists";
            }
        }
    
        if (inputIsValid)
        {
            // Insert code goes here
        }
        con.Close();
    }
