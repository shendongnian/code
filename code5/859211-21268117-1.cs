    public class ArtistService : IArtistService
    {
        public List<Artist>  ArtistDetail()  
        {
            using (ArtistDataContext db = new ArtistDataContext())
            {
                return db.Artists.ToList();
            }
        }
    }  
