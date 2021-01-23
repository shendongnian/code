     if (ModelState.IsValid)
        {
           Song song = GetSongById(originalSongId, db);
            Song relatedSong = GetSongById(relatedSongId, db);
            song.RelatedSongs.Add(relatedSong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
