    namespace WpfApplication1.Model
    {
        public class Movie
        {
            public Int64 Id { get; set; }
            public string name { get; set; }
        }
        public class MySqliteContext : DbContext
        {
            public DbSet<Movie> Movies { get; set; }
        }
    }
    List<Model.Movie> movies = new List<Model.Movie>();
    using (var context = new MySqliteContext())
        movies = context.Movies.ToList();
    foreach (var movie in movies)
        MessageBox.Show(movie.name.ToString());
