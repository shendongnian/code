    if (string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                        {
                            string sessionUserId = Session["UserId"] as string;
    
                            if (string.IsNullOrEmpty(sessionUserId))
                            {
    
                                Session["UserId"] = Server.HtmlEncode(s.user_id.ToString());
                            } FormsAuthentication.SetAuthCookie(tbUserName.Text, false);
                            Response.Redirect("~/");
                        }
                        else
                        {
                            string sessionUserId = Session["UserId"] as string;
    
                            if (string.IsNullOrEmpty(sessionUserId))
                            {
    
                                Session["UserId"] = Server.HtmlEncode(s.user_id.ToString());
                            }
                            FormsAuthentication.RedirectFromLoginPage(tbUserName.Text, false);
                        }
