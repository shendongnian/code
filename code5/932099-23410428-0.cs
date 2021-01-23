    Blog blog = new Blog 
    { 
        Name = name,
        Posts = new List<Post>()
    }; 
    foreach (var item in posts)
    {
        Post p = new Post();
        p.Title = item.Title;
        p.Content = item.Content;
        blog.Posts.Add(p);
    }
    
    db.Blogs.Add(blog); 
    db.SaveChanges(); 
