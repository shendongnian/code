    SqlDataReader dr = command.ExecuteReader();
    
    if(dr.Read())
    {
        if (dr[0].ToString() == username)
        {
            Session["UserAuthentication"] = username;
            Session.Timeout = 1;
            Response.Redirect("About.aspx");
        }
        else {
           // ...
        }
    }
