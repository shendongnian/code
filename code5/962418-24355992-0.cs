    var result1 = context.Blog.ToList();
    var postsLoaded = context.Posts.Local.Any(); // false.
   
    
    var result2 = context.Blog.Include(x => x.Posts).ToList();
    var postsLoaded = context.Posts.Local.Any(); // true. 
    // (if Blogs having Posts were loaded)
