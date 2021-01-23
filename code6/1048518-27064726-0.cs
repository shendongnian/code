    public class Order
    {
        private List<Pallet> _pallets = new List<Pallet>;
        internal void Add_pallet(Pallet pallet)
        {
            if (!this._pallets.Contains(pallet))
                this._pallets.Add(pallet);
        }
        //...other properties and methods...
    }
 
    public class Pallet
    {
        private Order _parent_order;
        private List<Box> _boxes = new List<Box>;
        public Pallet(Order parent_order)
        {
            if (parent_order = null)
                throw ArgumentNilException("parent_order must not be null");
            _parent_order = parent_order;
            _parent_order.Add_pallet(this);
        }
        //...other properties and methods...
    }
