    using(var db = new MyContext())
    {
        var user = db.Users.Find(id);
        Post post = new Post{ User = user, Content ="oO" };
        db.Posts.Add(post); // User is not added because it is known to the context.
        db.SaveChanges();
    }
