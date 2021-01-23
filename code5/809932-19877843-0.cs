     public abstract class Order
        {
            public abstract void PlaceOrder(); // log the placeing of the ordr, place the order asynchronously
        }
        public class MicrosoftOrder : Order // default order
        {
            public void PlaceOrder()
            {
                // default implementation for placing order.
            }
        }
        public class AppleOrder : Order // for asycn functionalities.
        {
            private Order order;
            public AppleOrder(Order order)
            {
                this.order = order;
            }
            public void PlaceOrder()
            {
                // Implement async functionalities.
                // you can also call default order as
                // order.PlaceOrder();
            }
        }
        public class GoogleOrder : Order // logged order
        {
            private Order order;
            public GoogleOrder(Order order)
            {
                this.order = order;
            }
            public void PlaceOrder()
            {           
                // Implement logged order
                // you can also call default order as
                // order.PlaceOrder();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Order order = new MicrosoftOrder();
                order.PlaceOrder(); // Default Order;
                Order orderWithAsync = new AppleOrder(order);
                orderWithAsync.PlaceOrder(); // Place order with asycn 
    
                Order orderWithAsyncAndlogging = new GoogleOrder(orderWithAsync);
                orderWithAsyncAndlogging.PlaceOrder(); // order with asynch and logging.            
            }
        }
