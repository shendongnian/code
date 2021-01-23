    // We will ask Unity to make one of these, so it has to resolve IRepository<Things>
    public class UsesThings
    {
        public readonly IRepository<Things> ThingsRepo;
        public UsesThings(IRepository<Things> thingsRepo)
        {
            this.ThingsRepo = thingsRepo;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            // Define a custom injection factory.
            // It uses reflection to create an object based on the requested generic type.
            var cachedRepositoryFactory = new InjectionFactory((ctr, type, str) =>
                {
                    var genericType = type.GenericTypeArguments[0];
                    var sqlRepoType = typeof (SqlRepository<>).MakeGenericType(genericType);
                    var sqlRepoInstance = Activator.CreateInstance(sqlRepoType);
                    var cachedRepoType = Activator.CreateInstance(type, sqlRepoInstance);
                    return cachedRepoType;
                });
            // Register our fancy reflection-loving function for IRepository<>
            container.RegisterType(typeof(IRepository<>), typeof(CachedRepository<>), new InjectionMember[] { cachedRepositoryFactory });
            // Now use Unity to resolve something
            var usesThings = container.Resolve<UsesThings>();
            usesThings.ThingsRepo.Get(); // "Getting object of type 'Things'!"
            usesThings.ThingsRepo.Get(); // "Using cached repository to fetch 'Things'!"
        }
    }
