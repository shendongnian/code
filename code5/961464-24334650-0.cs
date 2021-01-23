    public Item
    {
        public string A;
        public bool B;
        public char C;
        ...// 20 fields
    }
    public AdvancedItem
    {
        [DataMember]
        public Item   baseItem;
        [DataMember]
        public string Z;
    }
    public Item(Item item)
    {
        A = item.A;
        B = item.B;
        ...;//many lines
    }
    public AdvancedItem(Item item, string z) : base(Item)
    {
        baseItem = item; // or item.Clone();
        Z = z;
    }
