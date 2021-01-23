       if(HttpContext.Current.Session["username"] == null)
        {
           //Force them to redirect to the login page 
        }
        else
        {
            Response.Redirect("tothepageIwant.aspx");   
        }
if you want to do the same thing inside a using(){} statement
    string fullName = null;
    using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
    {
    	using (UserPrincipal user = UserPrincipal.FindByIdentity(context,"yourusernamehere")) //User.Identity.Name
    	{
    		if (user != null)
    		{
    			fullName = user.DisplayName;
    		}
    	}
    }
