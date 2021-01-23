     public ActionResult Create(string returnUrl, int DeviceID, string author, string comments)
     {
        string url = this.Request.UrlReferrer.AbsolutePath;
        Comment myComment = new Comment();
        comment.DeviceID = DeviceID;
        comment.Author = author;
        comment.Comments= comments;// I presume your Comment class has thoses properties if not you can see at least the way you can deal with that 
        if (ModelState.IsValid)
        {
            db.Comments.Add(myComment);
            db.SaveChanges();
            return Redirect(url);
        }
        return Redirect(url);
    }
