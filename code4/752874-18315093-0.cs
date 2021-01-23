    class BadClass
    {
        public int Value; // <- NOT preferred
    }
    class GoodClass
    {
        private int value;
        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
