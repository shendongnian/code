    bool isAttached = context.Users.Local.Any(x => x == user);
    if(!isAttached)
        contect.Users.Attach(user);
    
    //context.Entry(user).State = EntityState.Modified;
    context.Entry(user).State = EntityState.Deleted;
    context.SaveChanges();
