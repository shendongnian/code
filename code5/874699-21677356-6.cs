    public class MovieEqualityComparer : IEqualityComparer<Movie>
    {
        public bool Equals(Movie x, Movie y)
        {
            if ( x == null )
                return y == null;
            if ( y == null )
                return x == null;
            if ( object.ReferenceEquals(x, y) )
                return true;
            if ( !string.Equals(x.MovieName, y.MovieName) )
                return false;
            if ( !string.Equals(x.MovieRating, y.MovieRating) )
                return false;
            if ( !string.Equals(x.MovieRuntime, y.MovieRuntime) )
                return false;
            if ( !Enumerable.SequenceEqual(x.MovieActors, y.MovieActors) )
                return false;
            if ( !Enumerable.SequenceEqual(x.MovieImages, y.MovieImages) )
                return false;
            return true;
        }
    
        public int GetHashCode(Movie obj)
        {
            if ( obj == null )
            {
                throw new ArgumentNullException();
            }
            unchecked
            {
                int hash = 17;
                hash     = hash * 31 + ((obj.MovieName    == null) ? 0 : obj.MovieName.GetHashCode());
                hash     = hash * 31 + ((obj.MovieRating  == null) ? 0 : obj.MovieRating.GetHashCode());
                hash     = hash * 31 + ((obj.MovieRuntime == null) ? 0 : obj.MovieRuntime.GetHashCode());
                if ( obj.MovieActors != null )
                {
                    foreach ( var actor in obj.MovieActors )
                    {
                        hash = hash * 31 + ((actor == null) ? 0 : actor.GetHashCode());
                    }
                }
                if ( obj.MovieImages != null )
                {
                    foreach ( var image in obj.MovieImages )
                    {
                        hash = hash * 31 + ((image == null) ? 0 : image.GetHashCode());
                    }
                }
                return hash;
            }
        }
    }
