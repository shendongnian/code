    john.Friends.Remove(bob);
    context.SaveChanges();
    // OR
    var john = context.Users.Single(x => x.Username == "John");
    var walter = new User { UserId = 4 };
    
    context.Users.Attach(walter);
    
    john.Friends.Remove(walter);
    context.SaveChanges();
