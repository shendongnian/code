    protected void UserLoginOnLoggedIn(object sender, EventArgs e)
        {
            string itemid, itemdept;
            try
            {
                s1 = Request.QueryString["ItemID"].Trim();
                s2 = Request.QueryString["Dept"].Trim();
            }
            catch
            {
				//makes strings null if querystrings aren't present
                s1 = "";
                s2 = "";
            }
            string returnUrl = Request.QueryString["ReturnUrl"] + "&ItemID=" +
			    Request.QueryString["ItemID"] + "&Dept=" +
                            Request.QueryString["Dept"];
            if ((!String.IsNullOrEmpty(returnUrl) && !String.IsNullOrEmpty(s1) && 
            !String.IsNullOrEmpty(s2)))
                LoginUser.DestinationPageUrl = returnUrl;
            else
                LoginUser.DestinationPageUrl = "~/Default.aspx";
            Response.Redirect(LoginUser.DestinationPageUrl);
        } 
