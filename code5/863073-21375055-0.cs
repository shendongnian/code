    public ApplicationUser GetUser()
    {
        var user = new ApplicationUser
        {
            UserName = UserName,
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            ...
        };
        return user;
    }
