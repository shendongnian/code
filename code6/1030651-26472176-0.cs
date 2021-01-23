    public class Product
    {
        static Dictionary<SubCategory, Category> _categoriesMap;
        public static Product()
        {
            _categoriesMap = new Dictionary<SubCategory, Category>();
            _categoriesMap.Add(SubCategory.Apple, Category.Fruit);
        }
        public SubCategory SubCategory { get; set; }
        public Category Category
        {
            get { return _categoriesMap[this.SubCategory]; }
        }
    }
