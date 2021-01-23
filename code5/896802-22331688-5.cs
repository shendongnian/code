    public class Order
    {
        public Order()
        {
            _items = new List<OrderItems>();
        }
        private ICollection<OrderItems> _items;
        public virtual ICollection<OrderItems> Items 
        {
            get{ return _items.OrderByDescending(item => item.price).ToList(); }
            set{ _items = value; }
        }
    }
