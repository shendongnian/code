    public class PrefetchedRepositoryFactory
    {
        public Task<IRepository> CreateAsync()
        {
            //someOtherSlowRepo can be a parameter or instance field of this class
            var repo = new PrefetchedRepository(someOtherSlowRepo);
            await repo.Initialization;
            return repo;
        }
    }
