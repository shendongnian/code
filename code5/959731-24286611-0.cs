    	FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
        this.myUser,
        DateTime.Now,
        DateTime.Now.AddMinutes(30),
        this.isPersistent,
        String.Empty,  //Before I had this, Response.Redirect would return to Login
	    FormsAuthentication.FormsCookiePath);
        // Encrypt the ticket.
        string encTicket = FormsAuthentication.Encrypt(ticket);
        // Create the Cookie
        HttpCookie myCookie = FormsAuthentication.GetAuthCookie(this.myUser, this.isPersistent);
	
       if(this.isPersistent)
          myCookie.Expires = DateTime.Now.AddDays(3);
       else
          myCookie.Expires = DateTime.Now.AddMinutes(30);
	
       myCookie.HttpOnly = true;
       myCookie.Path = FormsAuthentication.FormsCookiePath;
       Response.Cookies.Add(myCookie);
       Response.Redirect("/Secure/km.aspx");
        
