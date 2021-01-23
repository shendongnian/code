    public class MyContext: DbContext
        {       
            public DbSet<League> Leagues { get; set; }
            public DbSet<Player> Players { get; set; }
            public DbSet<FantasyTeam> FantasyTeams { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<League>().HasKey(m => m.LeagueId);
                modelBuilder.Entity<Player>().HasKey(m => new { m.PlayerId, m.LeagueId })
                    .HasRequired<League>(m => m.League);
                modelBuilder.Entity<FantasyTeam>().HasKey(m => m.FantasyTeamId)
                    .Property(m => m.FantasyTeamId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                modelBuilder.Entity<FantasyTeam>().HasMany(t => t.Players).WithMany(p => p.FantasyTeams).Map(mc =>
                {
                    mc.ToTable("FantasyTeam_2_Player");
                    mc.MapLeftKey("FantasyTeamId");
                    mc.MapRightKey("PlayerId", "LeagueId");
                });
                base.OnModelCreating(modelBuilder);
            }
        }
