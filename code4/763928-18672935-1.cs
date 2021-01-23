    public class IdSpecification<T> : SpecificationBase<T> 
        where T : Entity
    {
        private readonly int _id;
        
        public IdSpecification(int id, IPredicateBuilderFactory builderFactory)
            : base(builderFactory)
        {
            _id = id;            
        }
        protected override void AddSatisfactionCriterion(IPredicateBuilder<T> predicateBuilder)
        {
            predicateBuilder.And(entity => entity.Id == _id);
        }
    }
