    if(Session["USER_NAME"] != null)
    {
        lblUserName.Text = Session["USER_NAME"].ToString();
    }
    else
    {
        Respinse.Redirect("Login.aspx");
    }
