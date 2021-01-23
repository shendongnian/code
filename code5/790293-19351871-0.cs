    public class SalesAllViewMode
    {
      IEnumerable<OrderProductVariant> _orderProductVariant;
      
      public SalesAllViewModel(IEnumerable<OrderProductVariant> orderProductVariant)
      {
        this._orderProductVariant = orderProductVariant;
      }
    }
