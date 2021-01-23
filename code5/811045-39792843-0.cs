            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            //start a try and catch method
          try
          {
          
           //create a principalcontext object
            var pc = new PrincipalContext(ContextType.Domain, "*****", user, pass);
             {
                
                
                   //validate the user credentials
                    if (pc.ValidateCredentials(user, pass))
                    {
                        //create a user identity
                        UserPrincipal userp = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, user);
                       
                        //check if the user is returned
                        if (userp != null)
                        {
                            //if user exists, return an array of authorized groups
                            var grps = userp.GetAuthorizationGroups();
                            
                            //convert the array to a list to enable search of CIS group
                            List<string> strList = grps.Select(o => o == null ? String.Empty : o.ToString()).ToList();
                            //check for CIS group from the list
                            if (strList.Contains("CISS"))
                            {
                                //create a session variable to show the loggedin user and set the error panel to false
                                Session["username"] = user;
                                ErrorPanel.Visible = false;
                                //redirect the user to the homepage
                                Response.Redirect("appdesk/account.aspx");
                            }
                            else if (!strList.Contains("CISS"))
                            {
                                Label1.Text = "You Don't have the Rights to login to the platfrom";
                                ErrorPanel.Visible = true;
                               
                        }
                    }
                     //if the user credentials are invalid
                    if (!pc.ValidateCredentials(user, pass))
                    {
                        Label1.Text = "Login Failed.Incorrect Username or Password";
                        ErrorPanel.Visible = true;
                        
                    }
                 }
            }
              //catch the exceptions in the try
           catch (Exception exc)
           {
                    Label1.Text = exc.Message.ToString();
                    ErrorPanel.Visible = true;                    
           }
