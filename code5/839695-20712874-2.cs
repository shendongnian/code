    public class Product
    {
        public int ID { set; get; }
        public string ProductName { set; get; }
        public int ProductCategoryID  {set;get;}
        public Category Category { set; get; }
    }
    public class Category
    {
        public int ID { set; get; }
        public string CategoryName { set; get; }
    }
