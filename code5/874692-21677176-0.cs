    public class MoviesEqualityComparer : IEqualityComparer<Movie>
    {
        public bool Equals(Movie x, Movie y)
        {
            return ..../* check all needed fields */
        }
        public int GetHashCode(Movie obj)
        {
            return .... /* get hashcode for movie objec*/
        }
    }
