    if (status.User!=null)
    {
        db.Users.Attach(status.User)
        db.Entry<User>(status.User).State = EntityState.Unchanged;
    }
