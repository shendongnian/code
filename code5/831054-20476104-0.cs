    using (var context = new BloggingContext())
    {
        var blog = context.Blogs.Find(1);
        var entityType = ObjectContext.GetObjectType(blog.GetType());
    }
