    Blog blog = null;
    DbPropertyValues originalBlogValues = null;
    //1: get from context
    using (var context = new BloggingContext()) 
    { 
        blog = context.Blogs.Find(1);
        originalBlogValues = context.Entry(blog).OriginalValues;
    }
    blog.Name = "Test 2";
    using (var context = new BloggingContext()) 
    {
        context.Blogs.Attach(blog);
        context.Entry(blog).OriginalValues.SetValues(originalBlogValues);
    }
