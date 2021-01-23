    public class RepositoryBase<TEntityModel> : IEntityRepository<TEntityModel>
    where TEntityModel : Entity
    {
        public IEnumerable<TEntityModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
    public class Repository<TDomainModel, TEntityModel> : RepositoryBase<TEntityModel>, IDomainRepository<TDomainModel>
        where TEntityModel : Entity
    {
        public new IEnumerable<TDomainModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
