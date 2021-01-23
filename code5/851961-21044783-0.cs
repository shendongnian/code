    if (comments.FirstOrDefault() !=null)
    {
        bpm.Blogs.BlogComment = new List<BlogComment>();
        foreach (var item in comments.ToList())
        {
            bpm.Blogs.BlogComment.Add(new BlogComment{Comments=item.Comments, LastModifed=item.LastModified});
        }
    }
