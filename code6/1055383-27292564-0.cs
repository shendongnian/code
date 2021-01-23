    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AddToEvent(Artist[] artistsSelected, int id = 0)
    {
        Event event = db.Events.Find(id);
        foreach (Artist artist in artistsSelected)
        {
            event.Artists.Add(artist);
        }
        return RedirectToAction("Index");
    }
