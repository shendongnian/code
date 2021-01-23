    // assuming you have a reference to the blog id in blogId
    foreach (var item in posts)
    {
        Post p = new Post();
        p.BlogId = blogId;
        p.Title = item.Title;
        p.Content = item.Content;
       db.Posts.Add(p);
    }
    db.SaveChanges();
