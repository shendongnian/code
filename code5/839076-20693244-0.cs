    // GET: /Comment/Create
    [Authorize]
    public ActionResult Create(int bookid)
    {
        var comment = new Comment();
        return View(comment);
    }
    //
    // POST: /Comment/Create
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public ActionResult Create(int bookid, Comment comment)
    {
        comment.Book = _bookService.GetBookFromBookId(bookid);
        comment.Owner = _userService.GetLoggedInUser();
        if (ModelState.IsValid)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Index","Book",null);
        }
        return View(comment);
    }
