    public Artist GetArtistByUrlFriendly(string urlFriendly)
    {
        var artist = _context.Artists.FirstOrDefault(a => 
            a.UrlFriendly == urlFriendly && a.Verified);
        if (artist != null)
            artist.Paintings = _context.Paintings.Where(p => 
                p.ArtistId == a.Id && p.Verified).ToList();
        return artist;
    }
