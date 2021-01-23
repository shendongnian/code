    if (Request.Cookies["Region"] != null)
    {
        TextBox5.Text = Server.HtmlEncode(Request.Cookies["Region"].Value);//read cookie
    }
    else{
        TextBox5.Text = String.Empty;
    }
