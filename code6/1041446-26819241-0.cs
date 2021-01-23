    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestConString"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT User_Type FROM [User] WHERE User_Id =@userid and User_Password=@password", con);
        cmd.Parameters.AddWithValue("@userid", Convert.ToInt32(txtUserName.Text));
        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
        var reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
    	reader.Read();
    	string userType = reader.GetString(0);
            Session["USER_ID"] = txtUserName.Text;
            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            Response.Write("Login Failed");
        }
