    public class IngredientViewModel
    {
        ...
    }
    public class RecipeViewModel
    {
        ...
    }
    public class NavigationViewModel
    {
        public IEnumerable<IngredientViewModel> Ingredients { get; set; }
        public IEnumerable<RecipeViewModel> Recipes { get; set; }
    }
