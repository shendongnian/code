    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Post post)
    {
        post.BlogUserEmail = User.Identity.Name
        try
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var email = User.Identity.Name;
            ViewBag.BlogUserEmail = new SelectList(db.BlogUsers, email);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }
        catch (DbEntityValidationException e)
        {
            var newException = new FormattedDbEntityValidationException(e);
            throw newException;
        }
    }
