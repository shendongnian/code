    public void Update(Movie movie)
    {
          var sql = "UPDATE myDB.movies set title=@Title, genre=@Genre where Id=@ID";
          db.Execute(sql, new 
                   {  Title = movie.Title, 
                      Genre = movie.Genre, 
                      ID = movie.ID 
                   });
    }
