    class TestDbContext : DbContext
    {
        public DbSet<Voyage> Voyages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voyage>()
                .HasKey(v => v.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
    public class VoyageNumber
    {
        private string _number;
        public VoyageNumber() { }
        public string Id
        {
            get
            {
                return _number;
            }
            set
            {
                if( !string.IsNullOrEmpty( _number ) )
                {
                    throw new InvalidOperationException("Id already set");
                }
                if( string.IsNullOrEmpty( value ) )
                {
                    throw new ArgumentException("Value cannot be null or empty string");
                }
                _number = value;
            }
        }
    }
    public class Voyage : VoyageNumber
    {
    }
