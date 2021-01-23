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
                return 17
                    +
                    31 * ((obj.MovieName == null) ? 0 : obj.MovieName.GetHashCode())
                    +
                    31 * ((obj.MovieRating == null) ? 0 : obj.MovieRating.GetHashCode())
                    +
                    31 * ((obj.MovieRuntime == null) ? 0 : obj.MovieRuntime.GetHashCode())
                    +
                    31 * ((obj.MovieActors == null) ? 0 : obj.MovieActors.GetHashCode())
                    +
                    31 * ((obj.MovieImages == null) ? 0 : obj.MovieImages.GetHashCode());
            }
        }
    }
