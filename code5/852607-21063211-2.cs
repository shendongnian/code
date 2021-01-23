    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
    }
    
    public class TimeSketchContext : DbContext, IDbContext
    {
        public virtual DbSet<EmployeeSkill> EmployeeSkill { get; set; }
    }
