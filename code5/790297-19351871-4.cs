    public class SalesAllViewModel
    {
      IEnumerable<OrderProductVariant> _orderProductVariant;
      
      public SalesAllViewModel(IEnumerable<OrderProductVariant> orderProductVariant)
      {
        this._orderProductVariant = orderProductVariant;
      }
    }
