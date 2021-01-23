    public class Response
    {
        public UserWrapper Users { get; set; }
        public MovieWrapper Movies { get; set; }
        public Response()
        {
            Users = new UserWrapper();
            Movies = new MovieWrapper();
        }
        public bool IsValid<T>() where T : IList
        {
            var property = this.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).First(p => p.PropertyType.Equals(typeof(T)));
            var collection = property.GetValue(this) as IList;
            return collection.Count > 0;
        }
    }
    public class User
    {
        // ...
    }
    public class Movie
    {
        // ...
    }
    public class UserWrapper : List<User>
    {
        // ...
    }
    public class MovieWrapper : List<Movie>
    {
        // ...
    }
