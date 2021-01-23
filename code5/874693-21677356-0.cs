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
                return
                    obj.MovieName.GetHashCode()
                    ^
                    obj.MovieRating.GetHashCode()
                    ^
                    obj.MovieRuntime.GetHashCode()
                    ^
                    obj.MovieActors.GetHashCode()
                    ^
                    obj.MovieImages.GetHashCode();
            }
        }
    }
