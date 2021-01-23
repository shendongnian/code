    public class SelectedItems
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal
        {
            get
            {
                if (Item == null)
                {
                    return 0m;
                }
                return Item.UnitPrice * Quantity; /* unit price should be decimal */
            }
        }
    }
