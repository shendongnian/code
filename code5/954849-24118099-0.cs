    using (UserPrincipal user = new UserPrincipal(ctx)) {
        user.Name = userName;
        user.UserPrincipalName = userName;
        user.SetPassword(password);
        user.Save();
        user.Enabled = true;
        user.Save();
    }
