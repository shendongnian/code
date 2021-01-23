    public void Update(Movie movie)
    {
      var sql = "UPDATE myDB.movies set title=@param1, genre=@param2 where ID=@param3";
      db.Execute(sql, new { param1 = movie.Title, param2 = movie.Genre, param3 = movie.ID });
    }
