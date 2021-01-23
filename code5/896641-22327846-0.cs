    private void AddSongs(Song song, List<int> tagIds)
    {
        _db.Songs.Add(song);
        foreach(var tagId in tagIds)
        {
            Tag tag = new Tag(){
                id = tagId
            };
            song.Tags.Add(tag);
        }
        _db.SaveChanges();
    }
