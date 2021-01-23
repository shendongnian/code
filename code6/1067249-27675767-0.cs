    protected void Logon_Click(object sender, EventArgs e)
    {
        if (_BLSecurity.VerifyUser(UserName.Text, UserPass.Text))
        {
            Session["currentUserProfile"] = GetUserProfile();
            Response.Redirect("../Default.aspx");
    
        }
        else
        {
            Msg.Text = "Invalid credentials. Please try again.";
        }
    }
