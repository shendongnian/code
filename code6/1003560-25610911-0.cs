    public UserDetails UserDetails
    {
        get
        {
            UserDetails userDetails = Session["UserDetails"] as UserDetails;
            if (userDetails == null)
            {
                userDetails = GetUserDetailsFromDatabase(HttpContext.Current.User.Identity.Name);
                Session["UserDetails"] = userDetails;
            }
            return userDetails;
        }
    }
