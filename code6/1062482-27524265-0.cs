    public ActionResult SampleBook5()
    {
        Book book = new Book
        {
            ID = 1,
            BookName = "Sample Book",
            Author = "Sample Author",
            ISBN = "Not available"
        };
    
        Session["BookData"] = book;
        return RedirectToAction("SampleBook6");
    }
    public ActionResult SampleBook6()
    {
        Book book = Session["BookData"] as Book;
    
        return View(book);
    }
