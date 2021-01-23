    var schema = new DbSchema(ConnectionString, DbPlatform.SqlServer2014);
    schema.Alter(db => db.CreateTable("Customer")
         .WithPrimaryKeyColumn("Id", DbType.Int32).AsIdentity()
         .WithNotNullableColumn("First_Name", DbType.String).OfSize(50)
         .WithNotNullableColumn("Last_Name", DbType.String).OfSize(50)
         ...);
