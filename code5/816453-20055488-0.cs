    var artist = this._db.Artists.Include(a => a.ArtistTypes)
        .SingleOrDefault(a => a.ArtistID == someArtistID);
    if (artist != null)
    {
        foreach (var artistType in artist.ArtistTypes
            .Where(at => vm.SelectedIds.Contains(at.ArtistTypeID)).ToList())
        {
            artist.ArtistTypes.Remove(artistType);
        }
        this._db.SaveChanges();        
    }
