    public interface IRecipe
    {
        public string Name { get; }
        public IEnumerable<string> Ingredients { get; }
        public int Difficulty { get; }
    }
    public class RecipeBook
    {
        private List<Recipe> recipes = new List<Recipe>();
        public IRecipe AddRecipe(string name, IEnumerable<string> ingredients,
            int difficulty)
        {
            if (recipes.Any(recipe => recipe.Name == name))
                throw new ArgumentException("Recipe name already exists");
            var result = new Recipe(name, ingredients, difficulty);
            recipes.Add(result);
            return result;
        }
        private class Recipe : IRecipe
        {
            public Recipe(string name, IEnumerable<string> ingredients,
                int difficulty)
            {
                Name = name;
                Ingredients = ingredients.ToList();
                Difficulty = difficulty;
            }
            public string Name { get; private set; }
            public IEnumerable<string> Ingredients { get; private set; }
            public int Difficulty { get; private set; }
        }
    }
