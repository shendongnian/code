    [ContractClass(typeof(ISpecificationContracts<>))]
    public interface ISpecification<TEntity> 
        where TEntity : class
    {
        bool IsSatisfiedBy(TEntity entity);
    }
    [ContractClassFor(typeof(ISpecification<>))]
    abstract class ISpecificationContracts<TEntity> 
        : ISpecification<TEntity> where TEntity : class
    {
        public bool IsSatisfiedBy(TEntity entity)
        {
            Contract.Requires(entity != null);
            throw new NotImplementedException();
        }
    }
    public class AndSpecification<TEntity> 
        : ISpecification<TEntity> where TEntity : class
    {
        private readonly ISpecification<TEntity> _first;
        private readonly ISpecification<TEntity> _second;
        protected ISpecification<TEntity> First {
            get
            {
                Contract.Ensures(Contract.Result<ISpecification<TEntity>>() != null);
                return _first;
            }
        }
        protected ISpecification<TEntity> Second
        {
            get
            {
                Contract.Ensures(Contract.Result<ISpecification<TEntity>>() != null);
                return _second;
            }
        }
        public bool IsSatisfiedBy(TEntity entity)
        {
            return First.IsSatisfiedBy(entity) && Second.IsSatisfiedBy(entity);
        }
        public AndSpecification(ISpecification<TEntity> first,
                                ISpecification<TEntity> second)
        {
            Contract.Requires(first != null);
            Contract.Requires(second != null);
            Contract.Ensures(_first == first);
            Contract.Ensures(_second == second);
            _first = first;
            _second = second;
        }
        [ContractInvariantMethod]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance", 
            "CA1822:MarkMembersAsStatic", 
            Justification = "Required for code contracts.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(_first != null);
            Contract.Invariant(_second != null);
        }
    }
