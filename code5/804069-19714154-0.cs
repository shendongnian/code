    public interface IUnitOfWork {
        int SaveChanges();
    }
    public class EFDbContext: DbContext, IUnitOfWork {
        public DbSet<User> User { get; set; }
        
        public EFDbContext(string connectionString)
            : base(connectionString) { }
        public override int SaveChanges() {
            return base.SaveChanges();
        }
    }
