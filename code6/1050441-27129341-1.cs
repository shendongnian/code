     if (ModelState.IsValid)
        {
           var song = GetSongById(originalSongId, db);
            var relatedSong = GetSongById(relatedSongId, db);
            song.RelatedSongs.Add(relatedSong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
