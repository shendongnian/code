    var existingBlog = new Blog { BlogId = 1, Name = "ADO.NET Blog" };
    using (var context = new BloggingContext())
    {
        // The next step implicitly attaches the entity
        context.Entry(existingBlog).State = EntityState.Modified;
        // Do some more work...
        context.SaveChanges();
    }
