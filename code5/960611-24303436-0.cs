    Public interface IMyDbContext
    {
        DbSet Votes { get; set;}
        void SaveChanges();
    }
     
    Public class MyDbContext : IdentityDbContext<User> , IMyDbContext
    {
        Public DbSet Votes { get; set;}
        
    }
    
    var mockVoteSet = new Mock<DbSet<Vote>>(){ CallBase = true };
    var _context = new Mock<IMyDbContext>(MockBehavior.Strict);
    _context.Setup(c => c.Votes).Returns(mockVoteSet.Object); 
    
    var service = new VoteService(_context.Object);
