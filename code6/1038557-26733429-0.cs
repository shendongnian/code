    IQueryable<Comment> dataquery = _db.Comments;
    int pagesize = 20; //20 items to be viewed on each page
    int page = 1;
    IList commentslist = dataquery.Skip((page - 1) * pagesize).Take(pagesize).ToList();
    foreach(Comment cmt in commentslist)
    {
        //Here you can trace comments items 
    }
