    public class LanguageService : ILanguageService
    {
        public ApplicationContext Context { get; set; }
        public DbSet<ILanguageEntity> DbSet
        {
            get
            {
                return Context.LanguageEntities;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<ILanguageEntity> LanguageEntities { get; set; }
    }
    public interface ILanguageService
    {
        DbSet<ILanguageEntity> DbSet { get; set; }
    }
