    public partial class PrimaryEntity
    {
        public PrimaryEntity()
        {
            ID = Guid.NewGuid();
        }
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public partial class DependentEntity
    {
        public DependentEntity()
        {
            ID = Guid.NewGuid();
        }
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid PrimaryEntityId { get; set; }
        public virtual PrimaryEntity CurrentPrimaryEntity { get; set; } 
    }
        // override this in DataContext
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DependentEntity>().HasRequired(a => a.CurrentPrimaryEntity).WithMany().HasForeignKey(a => a.CurrentBookId);
            base.OnModelCreating(modelBuilder);
        }
