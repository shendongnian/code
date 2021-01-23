    public enum OrderState
    {
        Taken,
        Approved,
        Payed,
        Emailed,
        BeforeShipment
        //etc.. etc..
     }
     public class Order : IStateObject<OrderStates>
     {
         //some linear fields of order..
         //: name, description, etc.. etc..
         public OrderStates State { get; set; }
         public void Process()
         {
             switch (State)
             {
                 case OrderState.Taken:
                     // code to handle this state
                     break;
                 case OrderState.Approved:
                     // etc..
                     break;
              }
             //persist myself to db.
         }
     }
