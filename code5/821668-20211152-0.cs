    public class TableBill
    {
        // the first way of initializing - by just passing the table number
        public TableBill(int tableNumber)
        {
            this.TableNumber = tableNumber;
        }
        // second option will use the first constructor to set table number (the ':this()' line)
        // and then set the order
        public TableBill(int tableNumber, TableOrder order)
            : this(tableNumber)
        {
            this.Order = order;
        }
    
        // the table number property has a private setter, so it will only be set 
        // from the constructors.
        public int TableNumber { get; private set; }
         
        // a completely public property for setting the order
        public TableOrder Order { get; set; }
    }
