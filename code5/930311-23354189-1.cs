    class Order
    {
        public int IdOrder;
        public string Product;
        public double Price;
        public int quantity;
        [Browsable(false)]
        public string MemberToBeHidden;
    }
