    public class ExternalRepository
    {
        // shared properties and methods
    }
    public class ExternalRepository<T> : ExternalRepository
        where T : class, IRepositoryable, new()
    {
        // own properties and methods
    }
    public static List<ExternalRepository> ExternalRepositories { get; set; }
