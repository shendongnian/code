    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Post mainPost = db.Posts.Find(id);
        if (mainPost == null)
        {
            return HttpNotFound();
        }
        var otherPosts = (from p in db.Posts
                          orderby p.DateAdded descending
                          select p).Take(4).ToList();
        var model = new PostDetailsViewModel
        {
            MainPost = mainpost,
            OtherPosts = otherPosts
        }
        return View(model);
    }
