      public class Order{
      ...
      List<Suborder> _suborders;
      
      public List<Suborder> Suborders{
      get {
            return _suborders ?? (_suborders = MyContext.Suborders.Where(X=>X.order_id==this.id).ToList());
           }
      ...
      }
