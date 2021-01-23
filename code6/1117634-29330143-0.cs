    public class Recipe
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int CategoryID { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
    public class Category
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
