    if (ModelState.IsValid)
    {
        relatedSong.ID = Guid.NewGuid();
        db.RelatedSongs.Add(relatedSong);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
