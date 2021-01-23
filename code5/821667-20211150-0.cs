    public class TableBill
    {
        public Order Order
        {
            get
            {
                return this._order;
            }
            set
            {
                this._order = value;
            }
        }
        private Order _order = null;
        public TableBill(int tableNumber)
        {
            // ...
        }
        public TableBill(int tableNumber, Order order)
        {
            // check for nulls etc...
            // ...
            this.Order = order;
        }
    }
