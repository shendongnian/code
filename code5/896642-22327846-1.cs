    private void AddSongs(Song song, List<int> tagIds)
    {
        _db.Songs.Add(song);
        foreach(var tagId in tagIds)
        {
            var tag = _db.Tags.SingleOrDefault(tagId);
            if(tag != null) song.Tags.Add(tag);
        }
        _db.SaveChanges();
    }
