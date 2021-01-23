    //here you read the token instagram generated and append it to the session, or get the error :) 
    
        if (!IsPostBack)
                    {
                        if (!SesssionInstaUser.isInSession())
                        {
                            if (Request.QueryString["code"] != null)
                            {
        
        
                                var token = AuthManager.getTokenId(Request.QueryString["code"]);
                                SesssionInstaUser.set(token);
                                //set login button to have option to log out
                                btnInstaAuth.Text = token.user.username + " leave instagtam oAuth";
                                Response.Redirect(Request.Url.ToString().Split('?')[0]);
                        }
                        else
                            if (Request.QueryString["error"] != null)
                            {
                                btnInstaAuth.Text = Request.QueryString["error_description"];
                            }
                    }
                }
