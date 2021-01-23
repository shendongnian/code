    public object Any(CustomAuth request)
    {
        //Authenticate User
        var session = base.SessionAs<CustomUserSession>();
        session.IsAuthenticated = true;
        this.SaveSession(session);        
    }
