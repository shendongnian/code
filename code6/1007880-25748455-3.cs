    public class T4Order : Attribute
    {
        private Int16 order;
        public T4Order(Int16 o)
        {
            this.order = o;
        }
        public Int16 Order
        {
            get { return this.order; }
            set { this.order = value; }
        }
    }
