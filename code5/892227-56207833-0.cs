    public class Order : Aggregate
    {
        public Order(IEnumerable<ShoppingCartItem> cart, Customer customer)
        {
            AddDomainEvent(new OrderCreated(cart, customer))
        }
    }
    public abstract class Aggregate
    {
        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
