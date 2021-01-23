    abstract class OrderHandler<T> where T : class
    {
        protected readonly Dictionary<Type, Func<BaseOrder, T>> OrderDispatcher;
        public OrderHandler()
        {
           OrderDispatcher = new Dictionary<Type, Func<BaseOrder, T>>
           {
                { typeof(OrderA), order => HandleOrder(order as OrderA) },
                { typeof(OrderB), order => HandleOrder(order as OrderB) },
                // ...
           };
        }
    
    	public T HandleOrder(BaseOrder order)
    	{
    	    return OrderDispatcher[order.GetType()](order);
        }
        protected abstract T HandleOrder(OrderA order);
        // ...
    }
    
    class InsertOrderHandler : OrderHandler<InsertOrderResult>
    {
        protected override InsertOrderResult HandleOrder(OrderA order)
    	{
    		// ...
    	}
        // ...
    }
