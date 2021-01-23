    public class ArtistService : IArtistService
    {
        public List<Artist>  ArtistDetail()  
        {
            using (ArtistDataContext db = new ArtistDataContext())
            {
                return (from artist in db.Artists
                        select new { // select only columns you need
                           artist.Id,
                           artist.Artist_name
                        })
                        .AsEnumerable() // execute query
                        .Select(x => new Artist { // create instance of class
                            Id = x.Id,
                            Artist_name = x.Artist_name
                        })
                        .ToList();
            }
        }
    }
