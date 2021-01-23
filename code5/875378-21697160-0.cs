    public partial OrderContext : DbContext, IContext
    {
        ...
    }
    
    public class OrderLineRepository : IOrderLineRepository
    {
        private OrderContext _context;
        public OrderLineRepository(IContext context)
        {
            this._context = (OrderContext)context;
        }
    }
