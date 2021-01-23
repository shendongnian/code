    public class LivePlayersDBContext : DbContext
        {
           public LivePlayersDBContext ():base("LivePlayersDBContext")
              {
              }     
            public DbSet<LivePlayers> Players { get; set; }
        }
