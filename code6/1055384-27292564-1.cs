    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AddToEvent(Artist[] artistsSelected, int id = 0)
    {
        Event _event = db.Events.Find(id);
        foreach (Artist artist in artistsSelected)
        {
            _event.Artists.Add(artist);
        }
        return RedirectToAction("Index");
    }
