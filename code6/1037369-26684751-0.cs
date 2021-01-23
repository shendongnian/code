    public class Recipe
    {
        public int ID { get; set; }
        public string Title { get; set; }
        // Other code
        // Navigation property
        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }
    }
    public class RecipeIngredient
    {
        public int ID { get; set; }
        public int RecipeID { get; set; }
        // Other code
    }
