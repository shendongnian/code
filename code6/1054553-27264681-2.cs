    var attachedUser = context.Users.Find(user.Id);
    if(attachedUser == null)
    {
        attachedUser = context.Users.Add(user);
    }
    else
    {
        context.Entry(attachedUser).State = EntityState.Modified;
    }
    
    context.SaveChanges();
