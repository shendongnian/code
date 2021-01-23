    var bloggs = bloggerDB.bloggers;
    bloggers.InsertOnSubmit(new Bloggers { Interest = "wy", Name = "opwn", TotalPosts = 1 });
    bloggers.InsertOnSubmit(new Bloggers { Interest = "ab", Name = "abcd", TotalPosts = 2 });
    bloggers.InsertOnSubmit(new Bloggers { Interest = "cd", Name = "1234", TotalPosts = 3 });
    bloggerDB.SubmitChanges();
