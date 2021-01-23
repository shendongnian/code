    List<Movie> listOfMovies = new List<Movie>();
    
    using(SqlConnection connection = new SqlConnection("Data Source=balder.ucn.dk;Initial Catalog=dmaa0213_6;********"))
    {
        using(SqlCommand cmd = new SqlCommand(connection))
        {
            cmd.CommandString = "SELECT * FROM movies ORDER BY MovieId";
            connection.Open();
            using(SqlDataReader reader = cmd.ExecuteDataReader())
            {
                while(reader.Read())
                {
                    Movie item = new Movie();
                    item.MovieId = reader.GetInt32(0);
                    item.MovieName = reader.GetString(1);
                    item.MovieLength = reader.GetString(2);
                    item.MovieDesc = reader.GetString(3);
                    listOfMovies.Add(item);
                }
            }
            connection.Close();
        }
    }
