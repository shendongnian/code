    public static class ProductExtension
    {
        public static IList<Category> GetCategories(this Product product)
        {
            List<Category> categories = new List<Category>();
            if (product.Category1 != null)
            {
                categories.Add(product.Category1);
            }
            if (product.Category2 != null)
            {
                categories.Add(product.Category2);
            }
            // etc.
            return categories;
        }
    }
