    var artist = new Artist
    {
        ArtistId = "5",
        Name = "Foo bar",
        Albums = new[]
        {
            new Album { Name = "Hello world!", Tracks = 9 }
        }
    };
    
    var response = await db.Entities.PutAsync(artist);
