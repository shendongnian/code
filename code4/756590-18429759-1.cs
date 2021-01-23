    //
    // POST: /Book/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize] // must be authenticated to be able to set UserId
    public ActionResult Create(Book book)
    {
       if (ModelState.IsValid)
       {
           UserId = ((ClaimsPrincipal)User).FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value`
           db.Books.Add(book);
           db.SaveChanges();
           return RedirectToAction("Index");
       }
       return View(book);
    }
    
