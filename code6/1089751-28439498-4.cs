    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }
    
        public virtual Recipe Recipe { get; set; } // <-- make this virtual
    }
