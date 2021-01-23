    var tracks = db.Tracks.Find(model.TrackId);
    tracks.TrackName = model.TrackName;
    tracks.TrackDescription = model.TrackDescription;
    db.Entry(tracks).State = EntityState.Modified;
    db.SaveChanges();
