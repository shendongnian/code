    try
    {
        // Make sure that there is an existing user, since this is an edit
        var existingUser = db.Users.FirstOrDefault(x => x.ID.Equals(user.Id));
        if (existingUser == null)
            throw new ValidationException("User not found");
        // Validate that the email address is unique, but only if it has changed
        if (!existingUser.EmailAddress.Equals(user.EmailAddress) &&
            db.Users.Any(x => x.EmailAddress.Equals(user.EmailAddress, StringComparison.InvariantCultureIgnoreCase)))
            throw new Exception(string.Format("Email address '{0}' is already in use", user.EmailAddress));
        // Move data to existing entity
        //existingUser.CurrentValues.SetValues(user);
        //Edit: 20/11/2014 - Jak
        db.Entry(existingUser).CurrentValues.SetValues(user);
        db.SaveChanges();
    }
    catch (Exception ex)
    {
        StaticConfig.Trace.Trace(SFTraceEvents.DbFailedUpdatingUser2, user.DisplayName,
            string.Format(ex.Message));
        ViewData.Add("DbError", ex.Message);
    }
