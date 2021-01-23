    struct Product
    {
        public string productName;
        public double productUnitPrice;
        public int productQty;
            public override string ToString()
            {
                return string.Format("Name: {0}, Price: {1}, Qty: {2}",productName,productUnitPrice,productQty);
            }
    }
