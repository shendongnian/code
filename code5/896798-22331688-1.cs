    public class Order
    {
        private ICollection<OrderItems> _items;
        public virtual ICollection<OrderItems> Items 
        {
            get{ return _items.OrderByDescending(item => item.price); }
            set{ _items = value; }
        }
    }
