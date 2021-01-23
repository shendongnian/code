     // entity
     public class Order
     {
         public bool Confirmed { get; set; }  
         public DateTime? ConfirmedAt { get; set; }
     }
    
     // business logic
     public class OrderManager
     {
         .................
         public void Confirm( Order order )
         {
             // changing of entity status
             order.Confirmed = true;
             order.ConfirmedAt = DateTime.Now;
    
             // storing new entity status
             _orderRepository.Update( order );
             ................
         }
     }
