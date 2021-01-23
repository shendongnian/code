    IDbSet<IdentityUser>  users = new DbSet<IdentityUser>
    {
        new IdentityUser { Id = "94ccfbae-8567-405e-8e2e-70a038cdde40" }
    };
    
    var dbContext = new Mock<MyDbContext<IdentityUser>>();
    dbContext.Setup(x => x.Users).Returns(() => users);
    
    var repository = new MyRepository<IdentityUser>(dbContext.Object);
