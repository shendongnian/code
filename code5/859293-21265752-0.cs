    public class ArtistService : IArtistService
    {
        public List<Artist>  ArtistDetail()  
        {
            using (ArtistDataContext db = new ArtistDataContext())
            {
                return (from artist in db.Artists
                        select new { // select only columns you need
                           artist.Id,
                           Artist.Artist_name
                        })
                        .AsEnumerable() // execute query
                        .Select(a => new Artist { // create instance of class
                            Id = a.Id,
                            Artist_name = a.Artist_name
                        })
                        .ToList();
            }
        }
    }
