    public class Order
        {
            public Action Action { get; set; }
            public int Id { get; set; }
            public int Price { get; set; }
    
            public Order(Action add, int id, int price){
                //Initialize
            }
        }
    
        public class Instrument
        {
            public string InstrumentName { get; set; }
            public Dictionary<int, Order> OrderBook { get; set; }
            
            public Instrument(string instrument)
            {
                InstrumentName = instrument;
                //OrderBook = new List<Order>();
            }
    
            public void AddOrder(Order order)
            {
                //Check order exist condition
                OrderBook.Add(order.Id, order);
            }
        }
