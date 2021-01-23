    public class SubscriberContext : DbContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Subscriber>().HasRequired(x => x.Address).WithRequiredPrincipal(x => x.Subscriber);
            modelBuilder.Entity<Subscriber>().HasOptional(x => x.Address).WithRequired(x => x.Subscriber);
            modelBuilder.Entity<SubscriberAddress>().Property(x => x.Id).HasColumnName("SubscriberId");
            base.OnModelCreating(modelBuilder);
        }
    }
    
    public class Subscriber
    {
        public Guid Id { get; set; }
        public virtual SubscriberAddress Address { get; set; }
    }
    
    public class SubscriberAddress
    {
        public Guid Id { get; set; }
        public virtual Subscriber Subscriber { get; set; }
    }
