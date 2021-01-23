    public static class ArtistListExtensions
    {
        public static String unionNames(this List<Artist> artists, String seperator)
        {
            return string.Join(seperator, artists.Select(a => a.ArtistName));
        }
    }
