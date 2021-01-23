    public class OrderSummaries
    {
      private readonly Dictionary<int, OrderSummary> _orderSummaries;
    
      public OrderSummary FindOrderSummary(int orderId)
      {
        return _orderSummaries[orderId];
      }
    
      ...
    }
