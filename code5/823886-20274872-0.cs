    public static class Products
    {
        public static List<String> lstProducts = new List<String>();
        public static void AddProducts(string product)
        {
            lstProducts.Add(product);
        }
        public static string DisplayProducts()
        {
            //return whatever you want lstproducts
            return "";
        }
    }
