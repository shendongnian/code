        public static Product SearchProductsByName(string ProductsName, List<Product> products)
        {
            Product pd;
            pd= new Product();
            foreach (Product rs in products)
            {
                if (ProductsName == rs.Name)
                {
                    return pd;
                }
            }   
            return null;    // <<< Return a value if nothing was found
        }
