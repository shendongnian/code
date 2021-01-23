    public class Products
    {
        public string ProductName;
        public int Units;
    }
    
    public class CustomerProducts
    {
        //assuming 1310860635 is the customer number
        public int CustomerNumber;
        // the timestamp can be the key which maps to the list of products retrieved
        public Dictionary<int, List<Products>> AvailableProducts;
    }
