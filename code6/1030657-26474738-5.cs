    public class Product {
        public Product(Category cat, Subcategory sub) {
            if (!sub.IsSubcategoryOf(cat)) throw new ArgumentException(
                String.Format("{0} is not a sub category of {1}.", sub, cat), "sub");
            Category = cat;
            Subcategory = sub;
        }
        public Category Category { get; private set; }
        public Subcategory Subcategory { get; private set; }
    }
