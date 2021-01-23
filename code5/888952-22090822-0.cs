    public interface IExternalRepository
    {
        // declaration of common properties and methods
    }
    public class ExternalRepository<T> : IExternalRepository
        where T : class, IRepositoryable, new()
    {
        // implementation of common properties and methods
        // own properties and methods
    }
    public static List<IExternalRepository> ExternalRepositories { get; set; }
