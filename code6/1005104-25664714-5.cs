    using (AuthRepository repository = new AuthRepository())
    {
        IdentityUser user = await repository.FindUser(context.UserName, context.Password);
    
        if (user == null)
        {
            context.SetError("invalid_grant", "The user name or password is incorrect");
            return;
        }
    
        var roles = repository.UserRoles(user.Id);
    }
