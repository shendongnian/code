    public class RepositoryNew<TDomainModel> : RepositoryBase<TDomainModel>
        where TDomainModel : Entity
    {
        public override IEnumerable<TDomainModel> GetAll() // --> the compiler complain to add "new" keyword, why ?
        {
        }
    }
