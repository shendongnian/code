    context.Upsert(
        p => p.UserName,   
        p => new { p.Active, p.FullName, p.Email },
        new User
        {
            Active = true, 
            FullName = "My user name",
            UserName = "ThisUser",
            Email = "my@email",
        }
    );
