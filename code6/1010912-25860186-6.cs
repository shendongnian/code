    public class Order
    {
        public Int32 ID { get; set; }
        public string Reference { get; set; }
        public Order() { }
        public Order(Int32 inID, string inReference)
        {
            this.ID = inID;
            this.Reference = (inReference == null) ? string.Empty : inReference;
        }
        //Very important 
        //Because ComboBox using .ToString method for showing Items in the list
        public override string ToString()
        {
            return this.Reference;
        }
    }
