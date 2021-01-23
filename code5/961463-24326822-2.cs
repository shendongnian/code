    public class AdvancedItem : Item
    {
        protected AdvancedItem(AdvancedItem other): this(other, other.Z)
        {
        }
        public AdvancedItem(Item item, string z): base(item)
        {
            Z = z;
        }
        public string Z;
    }
    public class EvenMoreAdvancedItem: AdvancedItem
    {
        public EvenMoreAdvancedItem(AdvancedItem advancedItem, double q): base(advancedItem)
        {
            Q = q;
        }
        public double Q;
    }
