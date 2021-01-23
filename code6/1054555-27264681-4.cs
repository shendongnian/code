    using(var newContext = new DataContext())
    {
        var attachedUser = newContext.Users.Attach(user);
        newContext.Entry(attachedUser).State = EntityState.Modified;
        newContext.SaveChanges();
    }
