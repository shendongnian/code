    //I used Order class as CustomType for ComboBox - use your own type
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
    //By this class I tried wrap ComboBox's items collection in own type. 
    //Where adding items must be concrete type
    //Here you can add other methods/properties you need (Remove)
    public class ComboBoxList<TCustomType>
    {
        private System.Windows.Forms.ComboBox.ObjectCollection _baseList;
        public ComboBoxList(System.Windows.Forms.ComboBox.ObjectCollection baseItems)
        {
            _baseList = baseItems;
        }
        public TCustomType this[Int32 index]
        {
            get { return (TCustomType)_baseList[index]; }
            set { _baseList[index] = value; }
        }
        public void Add(Order item)
        {
            _baseList.Add(item);
        }
        public Int32 Count { get { return _baseList.Count; } }
    }
    //Here our class derived from ComboBox
    class ComboBoxCustomType : System.Windows.Forms.ComboBox
    {
        //Hide base.Items property by our wrapping class
        public new ComboBoxList<Order> Items; 
        public ComboBoxCustomType() : base()
        {
            this.Items = new ComboBoxList<Order>(base.Items);
        }
    }
