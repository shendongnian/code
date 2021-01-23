    private class ReceiptItem
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
        public int Discount { get; set; }
        public decimal Total { get { return Cost * Amount; } }
    }
   
