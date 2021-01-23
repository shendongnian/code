    public interface IHomeUpContext
    {
        DbSet<channel> channel { get; set; }
        int SaveChanges();
    }
