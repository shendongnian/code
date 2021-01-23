    namespace Arbitrary
    {
        public class Order<T> : IEnumerable<T> where T : Item
        {
            private List<T> _lines = new List<T>();
            
            private decimal _totalValue;
            public decimal TotalValue
            {
                get { return updateValue(); }
            }
            internal decimal updateValue()    // modified
            {
                _totalValue = 0;
                foreach(T Item in _lines)
                {
                    _totalValue += Item.TotalCost;
                }
                return _totalValue;
            }
        }
        
        public class Item
        {
            private decimal _cost;
            private int _quantity;
            private decimal _totalCost;
            private Quote<Item> q;    // modified
            public Item(Quote<Item> q)    // modified
            {
                this.q = q;    // modified
            }
            public decimal Cost
            {
                get { return _cost; }
                set 
                { 
                    _cost = value;
                    _totalCost = (_cost * _quantity);
                    q.updateValue();    // modified
                }
            }
            public int Quantity
            {
                get { return _quantity; }
                set 
                { 
                    _quantity = value;
                    _totalCost = (_cost * _quantity);
                    q.updateValue();    // modified
                }
            }
            public decimal TotalCost
            {
                get { return _totalCost; }
            }
        }
    }
