    public class MovieList : List<Movie>
    {
       public MovieList()
       {
         Add(new Movie { Name = "Titanic", Actor = "xxx", });
         Add(new Movie { Name = "LordOFtheRings", Actor = "yyyy",  });
       }
    }
