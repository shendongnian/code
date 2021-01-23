     protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        Response.Redirect("www.");
        //OR
        var btn = ((System.Web.UI.WebControls.Button)(Login1.FindControl("LoginButton")));
        if (btn != null)
            btn.Text = "REDIRECT";
    }
