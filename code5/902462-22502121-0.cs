    public static class ArtistListExtensions
    {
        public static String unionNames(this List<Artist> artists, String seperator)
        {
            String unionString = "";
            foreach (Artist artist in artists) {
                unionString += artist.ArtistName + seperator; }
            if (!unionString.Equals("")) { 
                unionString = unionString.Substring(0, unionString.Length - seperator.Length); }
            return unionString;
        }
    }
