    Movies daMov = new Movies();
    // [...]
    foreach ( string genre in movieGenres )
            {
                Genres daGenre = await db.Genres.FirstOrDefaultAsync(
                       m => m.Genre_Name == genre);
    
                // doesn't exist - firstOrDefault() returns default
                if ( daGenre == null || object.Equals(daGenre, default(Genres)))               
                {
                    daGenre = new Genres(); // create new in db
                    daGenre.Genre_Name = genre;
                }
                daMov.Genres.Add( daGenre );
                db.Movies.Add(daMov);
                await db.SaveChangesAsync();
                
            }
