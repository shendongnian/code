    class BusinessLogic
    {
        List<Movie> movielist = new [] // No type needed, will be inferred
        {
            new Movie {Id=1, Name="pk", Duration=2, Price=200}
        }
        .ToList();
    }
