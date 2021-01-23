    public class RecipeVM
    {
      [Required]
      public string Name { get; set; }
      [Display(Name = Ingredient)]
      [Required]
      public List<int?> SelectedIngredients { get; set; }
      public SelectList IngredientList { get; set; }
    }
