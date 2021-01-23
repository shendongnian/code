    public class Recipe
    {
        public Recipe()
        {
            // set up a default collection during construction
            Ingredients = new List<Ingredient>();
            // could also be Ingredients = new Collection<Ingredient>();
        }
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }
    
        // private ICollection<Ingredient> _ingredients; <-- don't back
        public virtual ICollection<Ingredient> Ingredients
        {
            get; // <-- should never return null because of constructor
            protected set; // and because externals cannot set to null
        }
        public virtual User User { get; set; } // <-- make this virtual too
    }
