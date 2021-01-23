    public class MyEntity
    {
        [Key]
        public int MyEntityId { get; set; }
        public string MyProperty { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<MyEntity> MyEntities
        {
            get { return this.Set<MyEntity>(); }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var param = Expression.Parameter(typeof(MyEntity));
            var propertyExpression = Expression.Lambda(Expression.Property(param, "MyProperty"), param);
            modelBuilder.Entity<MyEntity>()
                .Property((Expression<Func<MyEntity, string>>)propertyExpression)
                .HasColumnName("Fish");
        }
    }
