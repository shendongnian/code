    public class BusinessRuleFailure : EventArgs
    {
        public BusinessRuleFailure(string reason)
        {
            Reason = reason;
        }
        public string Reason { get; private set; }
    }
    public delegate void BusinessRuleFailureHandler(BusinessRuleFailure failure);
    public interface ISpecification<T>
    {
        event BusinessRuleFailureHandler NotSatisified;
        Expression<Func<T, bool>> Predicate { get; }
        bool IsSatisfiedBy(T entity);
    }
    public class OrderProcessCommandHandler : ICommandHandler<Order>
    {
        OrderCommand _command;
        public OrderProcessCommandHandler(OrderCommand command) 
        {
           _command = command;
        }
        public Handle()
        {
            List<string> failures = new List<string>();
            var bigOrderSpec = new BigOrderSpecification();
            var specialOrderSpec = new SpecialOrderSpecification();
            bigOrderSpec.NotSatisified += failure => failures.Add(failure.Reason);
            specialOrderSpec.NotSatisified += failure => failures.Add(failure.Reason);
            var spec = bigOrderSpec.And(specialOrderSpec);
            if (spec.IsSatisfiedBy(_commnand.Order))
               // do some things
            else
            throw new BusinessException("Some business rules violated.", failures);
        } 
    }
