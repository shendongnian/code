    [AttributeUsage(AttributeTargets.Field)]
    public class SubcategoryOf : Attribute {
        public SubcategoryOf(Category cat) {
            Category = cat;
        }
        public Category Category { get; private set; }
    }
