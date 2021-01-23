            if (Session["productID"] != null&&!string.IsNullOrEmpty(Request.QueryString["redirect"]))
            {
                Session["user"] = user_name.ToString();
                Response.Redirect(Request.QueryString["redirect"].ToString()+"&ssid="+Session["authenticatedUser"].ToString());
          //Response.Redirect(ViewState["PreviousPage"].ToString());
           // Response.Redirect("~/shop/Cart.aspx?ssid="+Session["authenticatedUser"].ToString()+"&pr="+Session["productID"].ToString());
            }
            else
            {
                Session["user"] = user_name.ToString(); 
                Response.Redirect("Default.aspx");
            }
