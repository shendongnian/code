    public partial OrderContext : DbContext, IContext
    {
        ...
    }
    
    public class OrderLineRepository : IOrderLineRepository
    {
        public OrderLineRepository(string connectionString)
            : this(new OrderContext(connectionName))
        {
        }
    
        public OrderLineRepository(IContext context)
        {
            this.Context = (OrderContext)context;
        }
        public IContext Context { get; private set; }
    }
