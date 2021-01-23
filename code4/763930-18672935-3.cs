    public abstract class SpecificationBase<T> : ISpecification<T>
        where T : Entity
    {
        private readonly IPredicateBuilderFactory _builderFactory;
        private IPredicateBuilder<T> _predicateBuilder;
        
        protected SpecificationBase(IPredicateBuilderFactory builderFactory)
        {
            _builderFactory = builderFactory;            
        }
        public IPredicateBuilder<T> PredicateBuilder
        {
            get
            {
                return _predicateBuilder ?? (_predicateBuilder = BuildPredicate());
            }
        }
        protected abstract void AddSatisfactionCriterion(IPredicateBuilder<T> predicateBuilder);        
        private IPredicateBuilder<T> BuildPredicate()
        {
            var predicateBuilder = _builderFactory.Make<T>();
            predicateBuilder.Check(candidate => !candidate.IsDeleted)
            AddSatisfactionCriterion(predicateBuilder);
            return predicateBuilder;
        }
    }
