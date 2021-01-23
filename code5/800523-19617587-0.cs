    using (var d = new AutoDb())
    {
        var user = d.SystemUsers.FirstOrDefault( u => u.email == email);
        if (user != null && user.Password == crypto.Compute(password))
        {
            r = true;
        }
    }
