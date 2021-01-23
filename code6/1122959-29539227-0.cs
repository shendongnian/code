    public class MyDataContext: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           //...
           modelBuilder.Conventions.Add(new FunctionsConvention("dbo", this.GetType()));
        }
        // "CodeFirstDatabaseSchema" is a convention mandatory schema name
        // "LatLongDistanceCalc" is the name of your function
    
        [DbFunction("CodeFirstDatabaseSchema", "LatLongDistanceCalc")]
        public static int LatLongDistanceCalc(int fromLat, int fromLong,
                                                           int toLat, int toLong)
        {
           // no need to provide an implementation
           throw new NotSupportedException();
        }
    }
