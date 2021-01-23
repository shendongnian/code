    public ActionResult SearchResult(string name)
    {
       var ad=db.Advertisements.Where(s=>s.Title.ToUpper()==name.ToUpper())
                      .FirstOrDefault();
       if(ad!=null)
          return View(ad);
       //Nothing found for search for the name, Let's return the "NotFound" view
       return View("NotFound");
    }
