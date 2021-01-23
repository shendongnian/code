    public static void TypedUpdateExample() {
      var client = new MongoClient("mongodb://localhost:27017");
      var database = client.GetDatabase("test");
    
      var collection = database.GetCollection<Movie>("samples");
    
      //Create some sample data
      var movies = new Movie {
        Name = "TJ",
        Movies = new List<MovieData>
        {
          new MovieData {
            MovieName = "Star Wars: The force awakens"
          }
        }
      };
    
      collection.InsertOne(movies);
    
      //create a filter to retreive the sample data
      var filter = Builders<Movie>.Filter.Eq("_id", movies.Id);
    
      //var update = Builders<Movie>.Update.Set("name", "A Different Name");
      //TODO:LP:TSTUDE:Check for empty movies
      var update = Builders<Movie>.Update.Set(movie => movie.Movies[0].MovieName, "Star Wars: A New Hope");
      collection.UpdateOne(filter, update);
    }
    public class Movie {
      [BsonId]
      public ObjectId Id { get; set; }
      public string Name { get; set; }
      public List<MovieData> Movies { get; set; }
    }
    public class MovieData {
      [BsonId]
      public ObjectId Id { get; set; }
      public string MovieName { get; set; }
    }
