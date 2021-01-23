    if (dt.Rows.Count > 0)
        {
            //Store username in session
            Session["UserName"] = txtUserName.Text;
            Response.Redirect("StartPage.aspx");
        }
