    using (var db = new BlogContext())
    {
        var blog = db.Blogs.FirstOrDefault();
        
        //lazy loading the Posts of the blog that was fetched in previous line        
        foreach (var post in blog.Posts)
        {
            Trace.TraceInformation(string.Format("Title of post {0} is {1}",  post.Id, post.Title));
            }
        }
    }
