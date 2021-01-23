    public class Order
    {
        public int Id { get; set; }
    
        public int OrderAmount { get; set; }
    
        public virtual ObservableCollection<OrderItem> OrderItems 
        { 
             get
             {
                 if (orderItems == null)
                 {
                     orderItems = new ObservableCollection<OrderItem>();
                     orderItems.CollectionChanged += (s, args) => 
                     {
                         OrderAmount = OrderItems.Sum(item => item.Amount);
                     }
                 }
                 return orderItems;
             }
        }
        private readonly ObservableCollection<OrderItem> orderItems;
    }
