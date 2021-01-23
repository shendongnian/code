    public class WebsiteDBContext : DbContext
    {
        public WebsiteDBContext(DbContextOptions<WebsiteDBContext> options) : base(options)
        {
        }
        public DbSet<Global> Globals { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // it should be placed here, otherwise it will rewrite the following settings!
            base.OnModelCreating(builder);
            builder.Entity<Global>();
            builder.Entity<Global>(entity =>
            {
                entity.Property(global => global.MainTopic).HasMaxLength(150).IsRequired();
                entity.Property(global => global.SubTopic).HasMaxLength(300).IsRequired(false);
                entity.Property(global => global.Subject).IsRequired(false);
                entity.Property(global => global.URL).HasMaxLength(150).IsRequired(false);
            });
        }
    }
