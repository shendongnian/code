    bpm.Blogs.BlogComment = new List<BlogComment>();
    if (comments.FirstOrDefault() !=null)
    {
        foreach (var item in comments.ToList())
        {
            bpm.Blogs.BlogComment.Add(new BlogComment{Comments=item.Comments, LastModifed=item.LastModified});
        }
    }
