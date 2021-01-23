      public class Category {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Category Parent { get; set; }
        public IList<Category> Children { get; set; }
      }
