    using (var context = new BloggingContext())
    {
        // Will hit the database
        var blog = context.Blogs.Find(3);
    
        // Will return the same instance without hitting the database
        var blogAgain = context.Blogs.Find(3);
    
        context.Blogs.Add(new Blog { Id = -1 });
    
        // Will find the new blog even though it does not exist in the database
        var newBlog = context.Blogs.Find(-1);
    
        // Will find a User which has a string primary key
        var user = context.Users.Find("johndoe1987");
    }
