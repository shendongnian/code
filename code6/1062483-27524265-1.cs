    public ActionResult SampleBook3()
    {
        Book book = new Book
        {
            ID = 1,
            BookName = "Sample Book",
            Author = "Sample Author",
            ISBN = "Not available"
        };
    
        TempData["BookData"] = book;
        return RedirectToAction("SampleBook4");
    }
    
    public ActionResult SampleBook4()
    {
        Book book = TempData["BookData"] as Book;
    
        return View(book);
    }
