    protected string GetUserRole(Domain.Group entity)
    {
        var session = SessionAs<AuthUserSession>();
        var username = session.UserName;
        if (session.Roles.Contains("Admin"))
        {
            return "Admin";
        }
        if (entity.Id == default(int) || entity.Leader.Username.Equals(username))
        {
            return "Leader";
        }
        // More logic here...
        return session.IsAuthenticated ? "User" : "Anonymous";
    }
