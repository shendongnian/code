     public class Order
     {
         public bool Confirmed { get; set; }  
         public DateTime? ConfirmedAt { get; set; }
     }
    
     public class OrderManager
     {
         .................
         public void Confirm( Order order )
         {
             order.Confirmed = true;
             order.ConfirmedAt = DateTime.Now;
    
             _orderRepository.Update( order );
             ................
         }
     }
