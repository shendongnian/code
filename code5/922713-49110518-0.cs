        public class RepositoryFactory
    {
        public static dynamic CreateDynamic<TEntity>() where TEntity : BaseEntity
        {
            dynamic repositoryInstance = null;
            var subRepositories = AssemblyHelper.GetSubclassesOf(typeof(BaseRepository<TEntity>), true);
            var entityTypeName = typeof(TEntity).Name;
            var subRepository = subRepositories.FirstOrDefault(x => x.Name == entityTypeName + "Repository");
            if (subRepository != null)
            {
                var repositoryType = subRepository.UnderlyingSystemType;
                repositoryInstance = Activator.CreateInstance(repositoryType);
            }
            return repositoryInstance;
        }
    }
