    public class ShoppingBasket : IEnumerable<OrderItem>
    {
        private List<OrderItem> items = new List<OrderItem>();
        // ...
        public IEnumerator<OrderItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
