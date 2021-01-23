    using (var context = new BloggingContext())
    {
        var blog = context.Blogs.Find(1);
        context.Entry(blog).Property(u => u.Name).IsModified = true;     
        // Use a string for the property name
        context.Entry(blog).Property("Name").IsModified = true;
    }
