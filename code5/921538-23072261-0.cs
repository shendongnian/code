    SqlConnection conn = new SqlConnection( ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
    			
    DbModelBuilder builder = new DbModelBuilder(DbModelBuilderVersion.V6_0);
    builder.Configurations.Add(new EntityTypeConfiguration<TypeA>());
    
    builder.Entity<Tweet>().ToTable("Table1");
    
    using (MyEntities myEntities= new MyEntities (builder.Build(conn).Compile()))
    {
    	var a = myEntities.Tweets.ToList();//Return table 1
    }
    
    DbModelBuilder builder2 = new DbModelBuilder(DbModelBuilderVersion.V6_0);
    builder2.Configurations.Add(new EntityTypeConfiguration<TypeA>());
    builder2.Entity<TypeA>().ToTable("Table2");
    
    using (MyEntities myEntities= new MyEntities (builder.Build(conn).Compile()))
    {
    	var a = myEntities.Tweets.ToList();//Return table 2
    }
