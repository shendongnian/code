        public static void TestInaccessibleFKSetToNull( DbContextOptions options )
        {
            using( var dbContext = DeleteAndRecreateDatabase( options ) )
            {
                var p = new InaccessibleFKPrincipal();
                dbContext.Add( p );
                dbContext.SaveChanges();
                var d = new InaccessibleFKDependent()
                {
                    Principal = p,
                };
                dbContext.Add( d );
                dbContext.SaveChanges();
            }
            using( var dbContext = new TestContext( options ) )
            {
                var d = dbContext.InaccessibleFKDependentEntities.Single();
                d.Principal = null;
                dbContext.SaveChanges();
            }
            using( var dbContext = new TestContext( options ) )
            {
                var d = dbContext.InaccessibleFKDependentEntities
                    .Include( dd => dd.Principal )
                    .Single();
                System.Console.WriteLine( $"{nameof( d )}.{nameof( d.Principal )} is NULL: {null == d.Principal}" );
            }
        }
