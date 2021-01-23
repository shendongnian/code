    foreach (var song in downloads.results)
    {
       //Turn the list of artists into collection of names (strings)
       var artistNameCollection = song.artists.Select(artist => artist.name);
       //Assign to the property using String.Join to combine the collection
       song.artistsList = String.Join(", ", artistNameCollection);
    }
