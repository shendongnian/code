    class Item
    {
        public int A, B, C;
        public string D, E, F;
        private int privateInt;
        public Item(int valueOfPrivateField)
        {
            privateInt = valueOfPrivateField;
        }
    }
    class AdvancedItem : Item
    {
        public string G;
        public AdvancedItem(int valueOfPrivateField) : base(valueOfPrivateField)
        {
        }
    }
