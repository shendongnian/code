    public class SimpleExample
    {
            public int Id { get; set; }
            public string Name { get; set; }
    }
    //Set once before use (i.e. in a static constructor).
    OrmLiteConfig.DialectProvider = new SqliteOrmLiteDialectProvider();
    
    using (IDbConnection db = "/path/to/db.sqlite".OpenDbConnection())
    using (IDbCommand dbConn = db.CreateCommand())
    {
            dbConn.CreateTable<SimpleExample>(true);
            dbConn.Insert(new SimpleExample { Id=1, Name="Hello, World!"});
            var rows = dbConn.Select<SimpleExample>();
    
            Assert.That(rows, Has.Count(1));
            Assert.That(rows[0].Id, Is.EqualTo(1));
    }
