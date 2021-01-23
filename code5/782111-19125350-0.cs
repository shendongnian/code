    protected override bool IsAuthorized(HttpActionContext httpContext)
    {
        // code to map the session to the user.
        HttpContext.Current.Items["UserId"] = 23423; // set the user id to the Items collection
        return true;
    }
