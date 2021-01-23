    public class GenreComarer : IEqualityComparer<Genre>
    {
        public bool Equals(Genre x, Genre y)
        {
            return x.Name.Equals(y.Name);
        }
        public int GetHashCode(Genre obj)
        {
            return obj.Name.GetHashCode();
        }
    }
    public class AlbumComarer : IEqualityComparer<Album>
    {
        public bool Equals(Album x, Album y)
        {
            return x.Name.Equals(y.Name);
        }
        public int GetHashCode(Album obj)
        {
            return obj.Name.GetHashCode();
        }
    }
