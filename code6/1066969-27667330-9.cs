    class ProductInfo
    {
        public string Code { get; private set; }
        public int Quantity { get; private set; }
        public ProductInfo(string code, int quantity)
        {
            Code = code;
            Quantity = quantity;
        }
    }
