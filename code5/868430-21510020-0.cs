    [ChildActionOnly]
        public ViewResult GetPosts()
        {
        var posts = GetBlogPosts();
        var results = from post in posts
                      select new
                      {
                        Title = "This is the blog title",
                        Url = "www.google.com",
                        Author = "Bill Jones",
                        AuthorUrl = "www.billjones.com",
                        Description = "This is the description of the post"
                      };
        return PartialView("ViewName,posts); // the partial view name ,with posts object
    }
