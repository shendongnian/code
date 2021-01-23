    protected void Button1_Click(object sender, EventArgs e)
    {
        if (username.Text == "test" && password.Text == "test")
        {
            Response.Cookies["TheCookie"]["Username"] = username.Text;
            Response.Redirect("loggedIn.aspx");
        }
        else
        {
            Label1.Text = "Invalid Username and/or Password.";
        }
    }
