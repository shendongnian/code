    bloggerDB.bloggers.InsertAllOnSubmit(new[] {
        new Bloggers { Interest = "wy", Name = "opwn", TotalPosts = 1 },
        new Bloggers { Interest = "ab", Name = "abcd", TotalPosts = 2 },
        new Bloggers { Interest = "cd", Name = "1234", TotalPosts = 3 }
    });
    bloggerDB.SubmitChanges();
