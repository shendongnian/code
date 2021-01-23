    public class OrderSummaries
    {
      private readonly Dictionary<int, OrderSummary> _orderSummaries;
    
      public int FindOrderSummary(int orderId)
      {
        return _orderSummaries[orderId];
      }
    
      ...
    }
