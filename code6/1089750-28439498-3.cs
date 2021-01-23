    public class Recipe
    {
        public Recipe()
        {
            // set up a default collection at construction time...
            Ingredients = new List<Ingredient>();
        }
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }
    
        // private ICollection<Ingredient> _ingredients; <-- don't back
        public virtual ICollection<Ingredient> Ingredients
        {
            get; // <-- should never return null because of constructor...
            protected set; // and because externals cannot set
        }
        public User User { get; set; }
    }
