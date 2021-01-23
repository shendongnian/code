    public class OrderHandler{ 
      public static Dictionary<string,OrderHandler> Handlers = new Dictionary<string,OrderHandler>(){
      {"photo", new PhotoHandler()},
      {"canvas", new CanvasHandler()},
    };
    
      public virtual void Handle(Order order){
        var handler = handlers[order.OrderType];
        handler.Handle(order);
      } 
    }
    
    public class PhotoHandler: OrderHandler{...}
    public class CanvasHandler: OrderHandler{...}
     
