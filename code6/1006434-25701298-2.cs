    public class MyInitializer : CreateDatabaseIfNotExists<MyDbContext>
    {
      string _sql = "create trigger T_Ratings_Change " +
           "on dbo.Ratings after insert, update as " +
           "update Movies set SumOfAllRatings = " +
           "(select SUM(Rating) from Ratings where MovieId = inserted.MovieId) " +
           "from Movies inner join inserted ON Movies.Id = inserted.MovieId";
    
    
      protected override void Seed(MyContext context)
      {
        context.Database.ExecuteSqlCommand(_sql);
      }
    }
